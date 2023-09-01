using System;
using SponUI.Models;

namespace SponUI.Dto
{
	public class EventForUpdateDto
	{
        public string Photo { get; set; }

        public DateTime StartTime { get; set; }

        public Address Address { get; set; }

        public decimal Price { get; set; }

        public string Activity { get; set; }

        public string Place { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}

