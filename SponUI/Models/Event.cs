using System;
namespace SponUI.Models
{
	public class Event
	{
		private Image photo;

		public string Title;
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
		public DateTime StartTime;
		public decimal Distance;
		public decimal Price;
		public List<Attendant> Attendants;
	}
}

