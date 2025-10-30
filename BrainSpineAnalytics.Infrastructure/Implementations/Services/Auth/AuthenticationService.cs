using BrainSpineAnalytics.Application.Dtos.Requests.Auth;
using BrainSpineAnalytics.Application.Dtos.Responses.Auth;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Auth;
using BrainSpineAnalytics.Application.Interfaces.Security;
using BrainSpineAnalytics.Application.Interfaces.Services.Auth;
using BrainSpineAnalytics.Common.Configuration;
using BrainSpineAnalytics.Common.Constants;
using BrainSpineAnalytics.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Auth
{
 public class AuthenticationService : IAuthenticationService
 {
 private readonly IAuthRepo _authRepo;
 private readonly JwtSettings _jwtSettings;
 private readonly IPasswordHasher _hasher;

 public AuthenticationService(IAuthRepo authRepo, IOptions<JwtSettings> jwtOptions, IPasswordHasher hasher)
 {
 _authRepo = authRepo;
 _jwtSettings = jwtOptions.Value;
 _hasher = hasher;
 }

 public async Task<AuthResponse> LoginAsync(LoginRequestDto request)
 {
 var user = await _authRepo.GetByEmailAsync(request.Email);
 if (user is null)
 return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

 var valid = _hasher.Verify(request.Password, user.PasswordHash);
 if (!valid)
 return new AuthResponse { Success = false, Message = CommonConstants.Messages.InvalidCredentials };

 if (_hasher.IsLegacyHash(user.PasswordHash))
 {
 var newHash = _hasher.Hash(request.Password);
 await _authRepo.UpdatePasswordHashAsync(user.UserId, newHash);
 }

 var roles = await _authRepo.GetActiveRoleNamesByUserIdAsync(user.UserId);
 var token = GenerateJwtToken(user, roles);
 return new AuthResponse { Success = true, Message = CommonConstants.Messages.LoginSuccess, Token = token };
 }

 private string GenerateJwtToken(User user, IReadOnlyList<string> roles)
 {
 if (string.IsNullOrWhiteSpace(_jwtSettings.Key))
 throw new InvalidOperationException("JwtSettings.Key is not configured.");

 var keyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Key);
 if (keyBytes.Length <32)
 throw new InvalidOperationException("JwtSettings.Key must be at least256 bits (32 bytes).");

 var securityKey = new SymmetricSecurityKey(keyBytes);
 var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

 var now = DateTime.UtcNow;
 var claims = new List<Claim>
 {
 new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
 new Claim(JwtRegisteredClaimNames.Email, user.Email),
 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
 new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(now).ToString(), ClaimValueTypes.Integer64),
 new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
 new Claim("firstName", user.FirstName ?? string.Empty),
 new Claim("lastName", user.LastName ?? string.Empty)
 };

 foreach (var role in roles)
 {
 claims.Add(new Claim(ClaimTypes.Role, role));
 }

 var token = new JwtSecurityToken(
 issuer: _jwtSettings.Issuer,
 audience: _jwtSettings.Audience,
 claims: claims,
 notBefore: now,
 expires: now.AddMinutes(_jwtSettings.ExpiryMinutes),
 signingCredentials: creds
 );

 return new JwtSecurityTokenHandler().WriteToken(token);
 }

 public async Task<AuthResponse> RegisterAsync(SignupRequestDto request)
 {
 var existingUser = await _authRepo.GetByEmailAsync(request.Email);
 if (existingUser != null)
 return new AuthResponse { Success = false, Message = CommonConstants.Messages.EmailExists };

 var newUser = new User
 {
 FirstName = request.FirstName,
 LastName = request.LastName,
 Email = request.Email,
 PasswordHash = _hasher.Hash(request.Password)
 };

 await _authRepo.AddAsync(newUser);
 await _authRepo.AddUserRoleMappingAsync(newUser.UserId,2);

 return new AuthResponse { Success = true, Message = CommonConstants.Messages.UserRegistered };
 }
 }
}
