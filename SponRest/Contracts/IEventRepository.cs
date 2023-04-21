using System;
using SponRest.Models;

namespace SponRest.Contracts
{
	public interface IEventRepository
	{
		public Task<IEnumerable<Event>> GetEvents();
		public Task<Event> GetEvent(int id);
	}
}

