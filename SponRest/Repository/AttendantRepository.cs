using System;
using Dapper;
using SponRest.Context;
using SponRest.Contracts;
using System.Data;

namespace SponRest.Repository
{
    public class AttendantRepository : BaseRepository, IAttendantRepository
    {
        public AttendantRepository(DapperContext context) : base(context)
        {
        }

        public async Task JoinEvent(int eventId, int userId)
        {
            var procedureName = "dbo.usp_ATNDT_JoinEvent";

            var parameters = new DynamicParameters();
            parameters.Add("@event_id", eventId);
            parameters.Add("@user_id", userId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task LeaveEvent(int eventId, int userId)
        {
            var procedureName = "dbo.usp_ATNDT_LeaveEvent";

            var parameters = new DynamicParameters();
            parameters.Add("@event_id", eventId);
            parameters.Add("@user_id", userId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

