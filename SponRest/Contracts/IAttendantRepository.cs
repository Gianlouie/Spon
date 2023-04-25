using System;
namespace SponRest.Contracts
{
	public interface IAttendantRepository
	{
		public Task JoinEvent(int eventId, int userId);
		public Task LeaveEvent(int eventId, int userId);
	}
}

