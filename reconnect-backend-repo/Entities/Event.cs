using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace reconnect_backend_repo.Entities
{
    public class Event
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public decimal FirstPlacePrize { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public decimal SecondPlacePrize { get; set; }
        [Column(TypeName = "decimal(3,1)")]
        public decimal ThirdPlacePrize { get; set; }

        public int HostId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
        public int LocationId { get; set; }
        [JsonIgnore]
        public virtual Location? Location { get; set; }
        public int ActivityId { get; set; }
        [JsonIgnore]
        public virtual Activity? Activity { get; set; }
    }
}

