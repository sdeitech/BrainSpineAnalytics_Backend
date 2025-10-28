using BrainSpineAnalytics.Application.DTOs;
using BrainSpineAnalytics.Application.Interfaces.Repositories;
using BrainSpineAnalytics.Application.Interfaces.Services;
using BrainSpineAnalytics.Common.Constants;
using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthRepo _authRepo;
        public AuthenticationService(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _authRepo.GetByEmailAsync(request.Email);
            if (user is null)
                return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

            var incomingHash = HashPassword(request.Password);
            if (!string.Equals(user.PasswordHash, incomingHash, StringComparison.Ordinal))
                return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

            // Token generation can be added later
            return new AuthResponse { Success = true, Message = CommonConstants.Messages.LoginSuccess, Token = null };
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
