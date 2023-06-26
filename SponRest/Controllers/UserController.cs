using Microsoft.AspNetCore.Mvc;
using SponRest.Contracts;
using SponRest.Dto;

namespace SponRest.Controllers
{
    [ApiController]
	[Route("api/user")]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepo;

		public UserController(IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetUser(int id)
		{
			try
			{
				var user = await _userRepo.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

				return Ok(user);
			}
			catch (Exception e)
			{
                return StatusCode(500, e.Message);
            }
		}

		[HttpPost]
		public async Task<ActionResult> CreateUser(UserForCreationDto userForCreationDto)
		{
            try
            {
				await _userRepo.CreateUser(userForCreationDto);

				return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
		{
            try
            {
				var userToUpdate = _userRepo.GetUser(id);

				if (userToUpdate == null)
				{
					return NotFound();
				}

                await _userRepo.UpdateUser(userForUpdateDto, id);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteUser(int id)
		{
            try
            {
                var userToDelete = _userRepo.GetUser(id);

                if (userToDelete == null)
                {
                    return NotFound();
                }

                await _userRepo.DeleteUser(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
	}
}

