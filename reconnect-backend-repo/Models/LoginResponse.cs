using System;
namespace reconnect_backend_repo.Models
{
    public class LoginResponse
    {
        public string Username { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;

        public LoginResponse() { }
    }
}