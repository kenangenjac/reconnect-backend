using System;
using System.Security.Claims;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reconnect_backend_repo.Data;
using reconnect_backend_repo.Entities;
using reconnect_backend_repo.Interfaces;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Services
{
    public class EventService : IEventService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public EventService(DataContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<EventResponse>> GetAllEventsAsync()
        {
            var events = await _context.Events.ToListAsync();

            List<EventResponse> response = new();
            foreach(Event e in events)
            {
                var singleEvent = _mapper.Map<EventResponse>(e);
                response?.Add(singleEvent);
            }

            return response;
        }

        public async Task<EventResponse> GetEventAsync(int eventId)
        {
            var responseEvent = await _context.Events
                .Where(e => e.Id == eventId)
                .SingleAsync();

            return _mapper.Map<EventResponse>(responseEvent);
        }

        public async Task<EventResponse> AddEventAsync(EventRequest request)
        {
            if (_contextAccessor.HttpContext == null)
            {
                throw new Exception("You must be logged in to add an accommodation!");
            }

            var username = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            var activity = new Activity()
            {
                Name = request.Activity?.Name,
            };
            _context.Activities.Add(activity);

            var location = new Location()
            {
                Name = request.Location?.Name,
                Description = request.Location?.Description,
                Url = request.Location?.Url,                
            };
            _context.Locations.Add(location);

            var newEvent = new Event()
            {
                Name = request.Name,
                FirstPlacePrize = request.FirstPlacePrize,
                SecondPlacePrize = request.SecondPlacePrize,
                ThirdPlacePrize = request.ThirdPlacePrize,
                User = user,
                HostId = (int)(user?.Id)
            };
            newEvent.Activity = activity;
            newEvent.Location = location;

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();

            return _mapper.Map<EventResponse>(newEvent);
        }
    }
}

