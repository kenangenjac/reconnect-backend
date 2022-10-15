using System;
using System.ComponentModel.DataAnnotations;

namespace reconnect_backend_repo.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; } = String.Empty;

        public LoginRequest() { }
    }
}

