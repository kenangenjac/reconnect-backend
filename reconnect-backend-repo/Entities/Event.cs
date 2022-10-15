using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace reconnect_backend_repo.Entities
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty;
        [Column(TypeName = "decimal(3,1)")]
        public decimal FirstPlacePrize { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public decimal SecondPlacePrize { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public decimal ThirdPlacePrize { get; set; }

        public virtual User User { get; set; }

        public Event()
        {
        }
    }
}

