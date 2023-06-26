
using System;
using Newtonsoft.Json;
namespace SponUI.Models
{
	public class Attendant
	{
		private string firstName = string.Empty;
		private string lastName = string.Empty;
		private byte[] photo;

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
        public byte[] Photo64
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

		public Image Photo
		{
			get
			{
				if (photo != null)
				{
                    MemoryStream stream = new MemoryStream(photo);

                    ImageSource image = ImageSource.FromStream(() => stream);
                    return new Image { Source = image };
                }
				else
				{
					return new Image();
				}
			}
		}
    }
}

