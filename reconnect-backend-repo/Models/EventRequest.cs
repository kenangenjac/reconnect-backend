using System;
using reconnect_backend_repo.Entities;

namespace reconnect_backend_repo.Models
{
    public class EventRequest
    {
        public string Name { get; set; }
        public decimal FirstPlacePrize { get; set; }
        public decimal SecondPlacePrize { get; set; }
        public decimal ThirdPlacePrize { get; set; }
        
        public RegisterResponse? Host { get; set; }
        public LocationResponse? Location { get; set; }
        public AcitivityResponse Activity { get; set; }

        public EventRequest() { }
    }
}

