using AutoMapper;
using Microsoft.AspNet.Identity;
using MusicGo.Dtos;
using MusicGo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicGo.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();

            var notification = _context.UserNotifications
                                       .Where(un => un.UserId == userId && !un.IsRead)
                                       .Select(un => un.Notification)
                                       .Include(n => n.Gig.Artist)
                                       .ToList();

            return notification.Select(Mapper.Map<Notification, NotificationDto>);
        }
    }
}
