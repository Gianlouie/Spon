using System;
using System.Data;
using Dapper;
using SponRest.Context;
using SponRest.Contracts;
using SponRest.Models;

namespace SponRest.Repository
{
	public class EventRepository : IEventRepository
	{
		private readonly DapperContext _context;

		public EventRepository(DapperContext context)
		{
			_context = context;
		}

        public async Task<Event> GetEvent(int id)
        {
			var procedureName = "dbo.usp_EVENT_GetEvent";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _context.CreateConnection())
			{
                var eventDict = new Dictionary<int, Event>();

                var ev = await connection.QueryAsync<Event, Address, Coordinates, Attendant, Event>(
                    procedureName,
                    (ev, address, coordinates, attendant) =>
                    {
                        ev.Address = address;
                        ev.Coordinates = coordinates;

                        if (!eventDict.TryGetValue(ev.Id, out var currentEvent))
                        {
                            currentEvent = ev;
                            eventDict.Add(currentEvent.Id, currentEvent);
                        }

                        currentEvent.Attendants.Add(attendant);

                        return currentEvent;
                    },
					param: parameters,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "address1, longitude, id");

                return ev.FirstOrDefault();
			}
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var procedureName = "dbo.usp_EVENT_GetEvents";

			using (var connection = _context.CreateConnection())
			{
				var eventDict = new Dictionary<int, Event>();

				var events = await connection.QueryAsync<Event, Address, Coordinates, Attendant, Event>(
					procedureName,
					(ev, address, coordinates, attendant) =>
					{
						ev.Address = address;
						ev.Coordinates = coordinates;

						if (!eventDict.TryGetValue(ev.Id, out var currentEvent))
						{
							currentEvent = ev;
							eventDict.Add(currentEvent.Id, currentEvent);
						}

						currentEvent.Attendants.Add(attendant);

						return currentEvent;
					},
					commandType: CommandType.StoredProcedure,
					splitOn: "address1, longitude, id");


				return events.Distinct().ToList();
			}
        }
    }
}

