using System;
namespace reconnect_backend_repo.Entities
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;
       
        public virtual Event Event { get; set; }
        public virtual Activity Activity { get; set; }

        public Location() { }
    }
}

