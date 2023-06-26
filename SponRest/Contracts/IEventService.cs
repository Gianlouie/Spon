using System;
using SponRest.Models;

namespace SponRest.Contracts
{
	public interface IEventService
	{
        public Task<IEnumerable<Event>> GetEvents(Coordinates currentLocation);
    }
}

