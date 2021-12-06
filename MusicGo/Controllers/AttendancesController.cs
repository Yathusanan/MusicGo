using Microsoft.AspNet.Identity;
using MusicGo.Dtos;
using MusicGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicGo.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance Already Exists!");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
