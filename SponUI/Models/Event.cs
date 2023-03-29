using System;
namespace SponUI.Models
{
	public class Event
	{
		private string title = string.Empty;
		private Image photo = new Image() { Source = ImageSource.FromFile("default_image.png") };
		private DateTime startTime = DateTime.MinValue;
		private decimal distance = decimal.MinusOne;
		private decimal price = decimal.MinusOne;
		private List<Attendant> attendants = new List<Attendant>();

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

		public decimal Distance
		{
			get
			{
				return distance;
			}
			set
			{
				distance = value;
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
	}
}

