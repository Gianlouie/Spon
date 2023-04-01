
using System;
namespace SponUI.Models
{
	public class Attendant
	{
		private string firstName = string.Empty;
		private string lastName = string.Empty;
		private Image photo = new Image() { Source = ImageSource.FromFile("defaultpp.png") };

		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return lastName;
			}
			set
			{
				lastName = value;
			}
		}

		public Image Photo
		{
			get
			{
				return photo;
			}
			set
			{
				photo = value;
			}
		}
    }
}

