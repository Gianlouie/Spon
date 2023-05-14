using System;
using System.Data;
using Dapper;
using SponRest.Context;
using SponRest.Contracts;
using SponRest.Dto;
using SponRest.Models;

namespace SponRest.Repository
{
	public class UserRepository : BaseRepository, IUserRepository
	{
		public UserRepository(DapperContext context) : base(context)
		{
		}

        public async Task CreateUser(UserForCreationDto userForCreationDto)
        {
            var procedureName = "dbo.usp_USER_InsertUser";
            var parameters = new DynamicParameters();

            parameters.Add("@first_name", userForCreationDto.FirstName);
            parameters.Add("@last_name", userForCreationDto.LastName);
            parameters.Add("@photo", userForCreationDto.Photo);
            parameters.Add("@phone_num", userForCreationDto.PhoneNumber);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteUser(int id)
        {
            var procedureName = "dbo.usp_USER_DeleteUser";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<User> GetUser(int id)
        {
            var procedureName = "dbo.usp_USER_GetUser";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task UpdateUser(UserForUpdateDto userForUpdateDto, int id)
        {
            var procedureName = "dbo.usp_USER_UpdateUser";
            var parameters = new DynamicParameters();

            parameters.Add("@id", id);
            parameters.Add("@first_name", userForUpdateDto.FirstName);
            parameters.Add("@last_name", userForUpdateDto.LastName);
            parameters.Add("@photo", userForUpdateDto.Photo);
            parameters.Add("@phone_num", userForUpdateDto.PhoneNumber);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

