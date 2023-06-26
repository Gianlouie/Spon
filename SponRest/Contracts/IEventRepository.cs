using System;
using SponRest.Dto;
using SponRest.Models;

namespace SponRest.Contracts
{
	public interface IEventRepository
	{
		public Task<IEnumerable<Event>> GetEvents(string state);
		public Task<Event> GetEvent(int id);
		public Task<Event> CreateEvent(EventForCreationDto eventForCreationDto);
		public Task UpdateEvent(EventForUpdateDto eventForUpdateDto, int id);
		public Task DeleteEvent(int id);
	}
}

