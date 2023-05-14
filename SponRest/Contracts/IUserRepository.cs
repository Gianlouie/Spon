using System;
using SponRest.Dto;
using SponRest.Models;

namespace SponRest.Contracts
{
	public interface IUserRepository
	{
		public Task CreateUser(UserForCreationDto userForCreationDto);
		public Task<User> GetUser(int id);
		public Task UpdateUser(UserForUpdateDto userForUpdateDto, int id);
		public Task DeleteUser(int id);
	}
}

