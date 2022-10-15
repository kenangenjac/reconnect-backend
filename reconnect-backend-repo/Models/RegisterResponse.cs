using System;
namespace reconnect_backend_repo.Models
{
    public class RegisterResponse
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;

        public RegisterResponse() { }
    }
}

