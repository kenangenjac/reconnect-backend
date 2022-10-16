using System;
using Microsoft.AspNetCore.Mvc;
using reconnect_backend_repo.Interfaces;
using reconnect_backend_repo.Models;

namespace reconnect_backend_repo.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }
    }
}

