using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicGo.Models
{
    public class Gig
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }
        [Required]
        public int GenreId { get; set; }

        public ICollection<Attendance> Attendances { get; private set; }

        public Gig()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.GigCanceled(this);


            foreach (var ateendee in Attendances.Select(a => a.Attendee))
            {
                ateendee.Notify(notification);
            }
        }

        public void Modify(DateTime datetime, string venue, int genre)
        {
            var notification = Notification.GigUpdated(this, DateTime, Venue);
            
            Venue = venue;
            DateTime = datetime;
            GenreId = genre;

            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification); 
        }
    }
}