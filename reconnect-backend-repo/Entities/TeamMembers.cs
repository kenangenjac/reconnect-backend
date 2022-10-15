using System;
namespace reconnect_backend_repo.Entities
{
    public class TeamMembers
    {
        public Guid Id { set; get; } = Guid.NewGuid();

        public TeamMembers()
        {
        }
    }
}

