using System;
namespace SponUI.Models
{
	public class Event
	{
		private string title = string.Empty;
		private Image photo = new Image() { Source = ImageSource.FromFile("default_image.png") };
		private DateTime startTime = DateTime.MinValue;
		private string address = string.Empty;
		private decimal price = decimal.MinusOne;
		private List<Attendant> attendants = new List<Attendant>();
		private bool isSponsored = false;

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
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

		public string Address
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

		public bool IsSponsored
		{
			get
			{
				return isSponsored;
			}
			set
			{
				isSponsored = value;
			}
		}
	}
}

