using BrainSpineAnalytics.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using BrainSpineAnalytics.API.Models.Requests.AuthRequest;
using BrainSpineAnalytics.Application.DTOs.RequestDTOs.AuthDTO;

namespace BrainSpineAnalytics.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var appRequest = new SignupRequestDTO
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            var result = await _authService.RegisterAsync(appRequest);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var appRequest = new LoginRequestDTO
            {
                Email = request.Email,
                Password = request.Password
            };
            var result = await _authService.LoginAsync(appRequest);
            if (!result.Success) return Unauthorized(result);
            return Ok(result);
        }
    }
}
