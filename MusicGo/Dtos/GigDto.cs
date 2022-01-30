using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicGo.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; }

        public UserDto Artist { get; set; }

        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }

        public string Venue { get; set; }

        public GenreDto Genre { get; set; }

    }
}