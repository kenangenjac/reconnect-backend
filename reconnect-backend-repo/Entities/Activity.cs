using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace reconnect_backend_repo.Entities
{
    public class Activity
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

