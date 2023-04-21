using System;
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
			var query = "SELECT * FROM EVENT WHERE Id = @Id";

			using (var connection = _context.CreateConnection())
			{
				var ev = await connection.QuerySingleOrDefaultAsync<Event>(query, new { id });

				return ev;
			}
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
			var query = "SELECT * FROM EVENT";

			using (var connection = _context.CreateConnection())
			{
				var events = await connection.QueryAsync<Event>(query);

				return events.ToList();
			}
        }
    }
}

