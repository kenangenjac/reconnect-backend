using System;
namespace reconnect_backend_repo.Entities
{
    public class Team
    {
        public Guid Id { set; get; } = Guid.NewGuid();
        public string Name { set; get; } = String.Empty;

        public TeamMembers TeamMembers { get; set; }

        public Team() { }
    }
}

