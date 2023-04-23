using System;
using System.Data;
using Dapper;
using SponRest.Context;
using SponRest.Contracts;
using SponRest.Dto;
using SponRest.Models;

namespace SponRest.Repository
{
	public class EventRepository : BaseRepository, IEventRepository
	{
		public EventRepository(DapperContext context) : base(context)
		{
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

                return ev.SingleOrDefault();
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

		public async Task<Event> CreateEvent(EventForCreationDto eventForCreationDto)
		{
			var procedureName = "dbo.usp_EVENT_InsertEvent";

            var parameters = new DynamicParameters();

			parameters.Add("@user_id", eventForCreationDto.UserId);
			parameters.Add("@activity", eventForCreationDto.Activity);
			parameters.Add("@place", eventForCreationDto.Place);
			parameters.Add("@photo", eventForCreationDto.Photo);
			parameters.Add("@start_time", eventForCreationDto.StartTime);
			parameters.Add("@price", eventForCreationDto.Price);
			parameters.Add("@address1", eventForCreationDto.Address.Address1);
			parameters.Add("@address2", eventForCreationDto.Address.Address2);
			parameters.Add("@city", eventForCreationDto.Address.City);
			parameters.Add("@state", eventForCreationDto.Address.State);
			parameters.Add("@zip_code", eventForCreationDto.Address.ZipCode);
			parameters.Add("@latitude", eventForCreationDto.Coordinates.Latitude);
			parameters.Add("@longitude", eventForCreationDto.Coordinates.Longitude);

            using (var connection = _context.CreateConnection())
			{
				var id = await connection.QuerySingleAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);

				return await GetEvent(id);
			}
		}

		public async Task UpdateEvent(EventForUpdateDto eventForUpdateDto, int id)
		{
			var procedureName = "dbo.usp_EVENT_UpdateEvent";

            var parameters = new DynamicParameters();

			parameters.Add("@id", id);
            parameters.Add("@activity", eventForUpdateDto.Activity);
            parameters.Add("@place", eventForUpdateDto.Place);
            parameters.Add("@photo", eventForUpdateDto.Photo);
            parameters.Add("@start_time", eventForUpdateDto.StartTime);
            parameters.Add("@price", eventForUpdateDto.Price);
            parameters.Add("@address1", eventForUpdateDto.Address.Address1);
            parameters.Add("@address2", eventForUpdateDto.Address.Address2);
            parameters.Add("@city", eventForUpdateDto.Address.City);
            parameters.Add("@state", eventForUpdateDto.Address.State);
            parameters.Add("@zip_code", eventForUpdateDto.Address.ZipCode);
            parameters.Add("@latitude", eventForUpdateDto.Coordinates.Latitude);
            parameters.Add("@longitude", eventForUpdateDto.Coordinates.Longitude);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
			}
        }

		public async Task DeleteEvent(int id)
		{
			var procedureName = "dbo.usp_EVENT_DeleteEvent";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
			}

        }

		public async Task JoinEvent(int id, int userId)
		{
			var procedureName = "dbo.usp_EVENT_JoinEvent";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@user_id", id, DbType.Int32, ParameterDirection.Input);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
			}
        }
    }
}

