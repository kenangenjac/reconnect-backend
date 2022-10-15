using System;
using System.ComponentModel.DataAnnotations;

namespace reconnect_backend_repo.Models
{
    public class RegisterRequest
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = String.Empty;
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = String.Empty;
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; } = String.Empty;

        public RegisterRequest() { }
    }
}

