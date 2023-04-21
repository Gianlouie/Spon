using System;
using System.Net;
using SponRest.Enums;

namespace SponRest.Models
{
    public class Event
    {
        public string Title { get; set; }

        public string Photo { get; set; }

        public DateTime StartTime { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public List<Attendant> Attendants { get; set; }

        public EventStatus EventStatus { get; set; }

        public int AttendentCount { get; set; }

        public string Activity { get; set; }

        public string Place { get; set; }
    }
}

