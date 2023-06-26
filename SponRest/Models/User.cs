using System;
namespace SponRest.Models
{
	public class User
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Photo { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreateDate { get; set; }
    }
}

