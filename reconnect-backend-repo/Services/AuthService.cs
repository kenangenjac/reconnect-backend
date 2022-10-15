using System;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using reconnect_backend_repo.Data;
using reconnect_backend_repo.Entities;
using reconnect_backend_repo.Interfaces;
using reconnect_backend_repo.Models;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace reconnect_backend_repo.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(DataContext dataContext, IMapper mapper, IConfiguration configuration)
        {
            _context = dataContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _context.Users
                .Where(u => u.Username == request.Username)
                .SingleOrDefaultAsync();

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials");
            }

            var response = _mapper.Map<LoginResponse>(user);
            response.JwtToken = CreateToken(user);

            return response;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            if (_context.Users.Any(u => u.Email == request.Email || u.Username == request.Username))
            {
                throw new Exception("Invalid credentials");
            }

            Regex passwordCheckRegex = new("/^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$/");   // 8 char, 1 veliki, 1 mali, 1 br, i spec
            Regex usernameCheckRegex = new("/\\//g");
            
            if (!passwordCheckRegex.IsMatch(request.Password))
            {
                throw new Exception("Invalid password format");
            }

            if (!usernameCheckRegex.IsMatch(request.Username))
            {
                throw new Exception("Invalid username format");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<RegisterResponse>(user);
        }

        private string CreateToken(User user)
        {
            var tokenClaims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Username)
            };

            // accessing token key in appsettings.json
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // defining the payload of the jwt
            var token = new JwtSecurityToken(
                claims: tokenClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
