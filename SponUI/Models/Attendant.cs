
using System;
using Newtonsoft.Json;
namespace SponUI.Models
{
	public class Attendant
	{
		private string firstName = string.Empty;
		private string lastName = string.Empty;
		private Image photo = new Image() { Source = ImageSource.FromFile("defaultpp.png") };

		[JsonProperty("firstName")]
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

		[JsonProperty("lastName")]
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

		[JsonProperty("photo")]
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

