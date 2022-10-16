using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reconnect_backend_repo.Entities
{
    public class TeamMembers
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int UserId { set; get; }
        [JsonIgnore]
        public virtual User? User { set; get; }
        public int TeamId { set; get; }
        [JsonIgnore]
        public virtual Team? Team { set; get; }

    }
}

