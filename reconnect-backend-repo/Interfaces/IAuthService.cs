using System;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Interfaces
{
    public interface IAuthService
    {
        public Task<RegisterResponse> Register(RegisterRequest request);
        public Task<LoginResponse> Login(LoginRequest request);
    }
}

