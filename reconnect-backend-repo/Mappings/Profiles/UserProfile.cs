using System;
using AutoMapper;
using reconnect_backend_repo.Entities;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, LoginResponse>();
            CreateMap<User, RegisterResponse>();
            CreateMap<Event, EventResponse>();
        }
    }
}

