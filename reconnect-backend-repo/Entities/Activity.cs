using System;
namespace reconnect_backend_repo.Entities
{
    public class Activity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;

        public virtual Location Location { get; set; }
        public virtual Event Event { get; set; }

        public Activity() { }
    }
}

