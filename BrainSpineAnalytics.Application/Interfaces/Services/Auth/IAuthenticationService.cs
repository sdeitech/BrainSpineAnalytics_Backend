using BrainSpineAnalytics.Application.Dtos.Requests.Auth;
using BrainSpineAnalytics.Application.Dtos.Responses.Auth;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Auth
{
 public interface IAuthenticationService
 {
 Task<AuthResponse> RegisterAsync(SignupRequestDto request);
 Task<AuthResponse> LoginAsync(LoginRequestDto request);
 }
}
