using System;
namespace SponRest.Models
{
	public class User
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Photo { get; set; }

        public DateTime CreateDate { get; set; }
    }
}

