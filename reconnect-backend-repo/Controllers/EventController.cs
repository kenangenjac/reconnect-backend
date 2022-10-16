using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using reconnect_backend_repo.Interfaces;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Controllers
{
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService) {
            _eventService = eventService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EventResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllEventsAsync()
        {
            var response = await _eventService.GetAllEventsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetEventAsync([FromRoute] int id)
        {
            var response = await _eventService.GetEventAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(EventResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> AddEventAsync([FromBody] EventRequest request)
        {
            var response = await _eventService.AddEventAsync(request);
            return Ok(response);
        }
    }
}

