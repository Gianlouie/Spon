using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.Contracts;
using SponRest.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SponRest.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepo;

        public EventsController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            try
            {
                var events = await _eventRepo.GetEvents();
                return Ok(events);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "EventById")]
        public async Task<ActionResult> GetEvent(int id)
        {
            try
            {
                var ev = await _eventRepo.GetEvent(id);

                if (ev == null)
                    return NotFound();

                return Ok(ev);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateEvent(EventForCreationDto eventForCreationDto)
        {
            try
            {
                var createdEvent = await _eventRepo.CreateEvent(eventForCreationDto);

                return CreatedAtRoute("EventById", new { id = createdEvent.Id }, createdEvent);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, EventForUpdateDto eventForUpdateDto)
        {
            try
            {
                var eventToUpdate = await _eventRepo.GetEvent(id);

                if (eventToUpdate == null)
                {
                    return NotFound();
                }

                await _eventRepo.UpdateEvent(eventForUpdateDto, id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            try
            {
                var eventToUpdate = await _eventRepo.GetEvent(id);

                if (eventToUpdate == null)
                {
                    return NotFound();
                }

                await _eventRepo.DeleteEvent(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

