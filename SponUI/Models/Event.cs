using System;
using SponUI.Enums;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;

namespace SponUI.Models
{
	public class Event
	{
		private string title = string.Empty;
		private Image photo = new Image() { Source = ImageSource.FromFile("default_image.png") };
		private DateTime startTime = DateTime.MinValue;
		private Address address = new Address();
		private decimal price = decimal.MinusOne;
		private List<Attendant> attendants = new List<Attendant>();
		private EventStatus eventStatus = EventStatus.None;
		private string activity = string.Empty;
		private string place = string.Empty;
		private float distance = 0;
		private string startingIn = string.Empty;

		public string Title
		{
			get
			{
				return activity + " @ " + place;
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

		[JsonProperty("startTime")]
		public DateTime StartTime
		{
			get
			{
				return startTime;
			}
			set
			{
				startTime = value;
			}
		}

		[JsonProperty("address")]
		public Address Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}

		[JsonProperty("price")]
		public decimal Price
		{
			get
			{
				return price;
			}
			set
			{
				price = value;
			}
		}

		[JsonProperty("attendants")]
		public List<Attendant> Attendants
		{
			get
			{
				return attendants;
			}
			set
			{
				attendants = value;
			}
		}

		[JsonProperty("eventStatus")]
		public EventStatus EventStatus
		{
			get
			{
				return eventStatus;
			}
			set
			{
				eventStatus = value;
			}
		}

		public int AttendentCount
		{
			get
			{
				return attendants.Count();
			}
		}

		[JsonProperty("activity")]
		public string Activity
		{
			get
			{
				return activity;
			}
			set
			{
				activity = value;
			}
		}

		[JsonProperty("place")]
		public string Place
		{
			get
			{
				return place;
			}
			set
			{
				place = value;
			}
		}

		[JsonProperty("distance")]
		public string Distance
		{
			get
			{
				return distance.ToString("0.00");
			}
			set
			{
				distance = float.Parse(value);
			}
		}

		public string StartingIn
		{
			get
			{
				TimeSpan span = StartTime - DateTime.Now;

				if (span.Minutes > 0)
				{
					return String.Format("{0}:{1}",
					span.Hours.ToString().PadLeft(2, '0'), span.Minutes.ToString().PadLeft(2,'0'));
				}
				else
				{
					return "0:00";
				}
            }
        }
    }
}

