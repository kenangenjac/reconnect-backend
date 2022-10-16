using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using reconnect_backend_repo.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace reconnect_backend_repo.Models
{
	public class EventResponse
	{
        public string Name { get; set; }
        public decimal FirstPlacePrize { get; set; }
        public decimal SecondPlacePrize { get; set; }
        public decimal ThirdPlacePrize { get; set; }

        public Activity? Activity { get; set; }
        public User? Host { get; set; }
        public Location? Location { get; set; }

        public EventResponse() { }
	}
}

