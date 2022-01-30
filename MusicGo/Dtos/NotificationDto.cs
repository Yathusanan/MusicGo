using MusicGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicGo.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        public Gig Gig { get; set; }
    }
}