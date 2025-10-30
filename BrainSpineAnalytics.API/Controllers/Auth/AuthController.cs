using BrainSpineAnalytics.Application.Interfaces.Services.Auth  ;
using Microsoft.AspNetCore.Mvc;
using BrainSpineAnalytics.API.Models.Requests.AuthRequest;
using BrainSpineAnalytics.Application.Dtos.Requests.Auth;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var appRequest = new SignupRequestDto
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
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var appRequest = new LoginRequestDto
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
