using System;
namespace reconnect_backend_repo.Models
{
    public class LocationResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public LocationResponse() { }
    }
}