using BrainSpineAnalytics.Application.DTOs;
using BrainSpineAnalytics.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers
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
            public async Task<IActionResult> Register([FromBody] RegisterRequest request)
            {
                var result = await _authService.RegisterAsync(request);
                if (!result.Success) return BadRequest(result);
                return Ok(result);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequest request)
            {
                var result = await _authService.LoginAsync(request);
                if (!result.Success) return Unauthorized(result);
                return Ok(result);
            }
        }
}
