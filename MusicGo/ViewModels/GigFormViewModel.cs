﻿using MusicGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicGo.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime DateTime 
        {
            get { return DateTime.Parse(string.Format("{0} {1}", Date, Time))} 
        }
    }
}