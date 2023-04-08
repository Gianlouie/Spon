using System;
using System.Net;
using SponRest.Enums;

namespace SponRest.Models
{
    public class Event
    {
        private string title = string.Empty;
        private string photo = string.Empty;
        private string address = string.Empty;
        private decimal price = decimal.MinusOne;
        private List<Attendant> attendants = new List<Attendant>();
        private EventStatus eventStatus = EventStatus.None;

        public string Title
        {
            get => title; set => title = value;
        }

        public string Photo
        {
            get => photo; set => photo = value;
        }

        public DateTime StartTime
        {
            get; set;
        }

        public string Address
        {
            get => address; set => address = value;
        }

        public decimal Price
        {
            get => price; set => price = value;
        }

        public List<Attendant> Attendants
        {
            get => attendants; set => attendants = value;
        }

        public EventStatus EventStatus
        {
            get => eventStatus; set => eventStatus = value;
        }
    }
}

