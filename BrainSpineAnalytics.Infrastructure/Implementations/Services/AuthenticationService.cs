using BrainSpineAnalytics.Application.Configuration;
using BrainSpineAnalytics.Application.DTOs;
using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Application.Interfaces.Services;
using BrainSpineAnalytics.Common.Constants;
using BrainSpineAnalytics.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthRepo _authRepo;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(IAuthRepo authRepo, IOptions<JwtSettings> jwtOptions)
        {
            _authRepo = authRepo;
            _jwtSettings = jwtOptions.Value;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _authRepo.GetByEmailAsync(request.Email);
            if (user is null)
                return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

            var incomingHash = HashPassword(request.Password);
            if (!string.Equals(user.PasswordHash, incomingHash, StringComparison.Ordinal))
                return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

            var token = GenerateJwtToken(user);
            return new AuthResponse { Success = true, Message = CommonConstants.Messages.LoginSuccess, Token = token };
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("firstName", user.FirstName ?? string.Empty),
                new Claim("lastName", user.LastName ?? string.Empty)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _authRepo.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return new AuthResponse { Success = false, Message = CommonConstants.Messages.EmailExists };

            var newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = HashPassword(request.Password)
            };

            await _authRepo.AddAsync(newUser);

            return new AuthResponse { Success = true, Message = CommonConstants.Messages.UserRegistered };
        }
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
