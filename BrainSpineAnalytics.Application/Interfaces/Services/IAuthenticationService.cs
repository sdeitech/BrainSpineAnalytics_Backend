using BrainSpineAnalytics.Application.DTOs.RequestDTOs.AuthDTO;
using BrainSpineAnalytics.Application.DTOs.ResponseDTOs;

namespace BrainSpineAnalytics.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthResponse> RegisterAsync(SignupRequestDTO request);
        Task<AuthResponse> LoginAsync(LoginRequestDTO request);
    }
}
