using System;
using System.Net;
using SponRest.Enums;

namespace SponRest.Models
{
    public class Event
    {
        public int Id { get; set; }

        public byte[] Photo { get; set; }

        public DateTime StartTime { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public string Activity { get; set; }

        public string Place { get; set; }

        public Coordinates Coordinates { get; set; }

        public List<Attendant> Attendants { get; set; } = new List<Attendant>();

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public float Distance { get; set; }
    }
}

