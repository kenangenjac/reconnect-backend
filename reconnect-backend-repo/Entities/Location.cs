using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace reconnect_backend_repo.Entities
{
    public class Location
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Url { get; set; } 
        public int? ActivityId { get; set; }
        [JsonIgnore]
        public virtual Activity? Activity { get; set; }
    }
}

