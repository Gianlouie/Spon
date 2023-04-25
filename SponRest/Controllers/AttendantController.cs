using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.Contracts;
using SponRest.Dto;

namespace SponRest.Controllers
{
	[ApiController]
	[Route("api/attendant")]
	public class AttendantController : Controller
	{
		private readonly IAttendantRepository _attendantRepo;
		private readonly IEventRepository _eventRepo;

		public AttendantController(IAttendantRepository attendantRepo, IEventRepository eventRepo)
		{
			_attendantRepo = attendantRepo;
			_eventRepo = eventRepo;
		}

		[HttpPost]
		public async Task<ActionResult> JoinEvent(int eventId, int userId)
		{
			var eventToJoin = await _eventRepo.GetEvent(eventId);

			if (eventToJoin == null)
			{
				return NotFound();
			}

			await _attendantRepo.JoinEvent(eventId, userId);

			return NoContent();
        }

		[HttpDelete]
		public async Task<ActionResult> LeaveEvent(int eventId, int userId)
		{
			var eventToLeave = await _eventRepo.GetEvent(eventId);

			if (eventToLeave == null)
			{
				return NotFound();
			}

			await _attendantRepo.LeaveEvent(eventId, userId);

			return NoContent();
		}
	}
}

