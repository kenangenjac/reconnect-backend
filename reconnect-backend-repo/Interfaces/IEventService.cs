using System;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Interfaces
{
    public interface IEventService
    {
        public Task<List<EventResponse>> GetAllEventsAsync();
        public Task<EventResponse> GetEventAsync(int eventId);
        public Task<EventResponse> AddEventAsync(EventRequest request);
    }
}

