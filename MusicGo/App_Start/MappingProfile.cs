using AutoMapper;
using MusicGo.Dtos;
using MusicGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicGo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
           
    }
}