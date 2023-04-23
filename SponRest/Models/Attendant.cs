using System;

namespace SponRest.Models
{
    public class Attendant : User
    {
        public int EventId { get; set; }

        public bool IsHost { get; set; }

        public DateTime JoinDate { get; set; }
    }
}

