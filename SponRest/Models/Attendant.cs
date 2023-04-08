using System;

namespace SponRest.Models
{
    public class Attendant
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string photo = string.Empty;

        public string FirstName
        {
            get => firstName; set => firstName = value;
        }

        public string LastName
        {
            get => lastName; set => lastName = value;
        }

        public string Photo
        {
            get => photo; set => photo = value;
        }
    }
}

