using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SponRest.Contracts;
using SponRest.Dto;
using SponRest.Models;
using SponRest.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SponRest.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepo;
        private readonly IEventService _eventService;

        public EventsController(IEventRepository eventRepo, IEventService eventService)
        {
            _eventRepo = eventRepo;
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents([FromQuery]Coordinates currentLocation)
        {
            try
            {
                var events = await _eventService.GetEvents(currentLocation);

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

