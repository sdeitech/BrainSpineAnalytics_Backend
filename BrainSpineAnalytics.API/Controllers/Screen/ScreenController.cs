using BrainSpineAnalytics.Application.Interfaces.Services.Menu;
using BrainSpineAnalytics.Application.Interfaces.Services.Screen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Screen
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenController : ControllerBase
    {
        private readonly IScreenService _screenService;

        public ScreenController(IScreenService screenService)
        {
            _screenService = screenService;
        }
        [HttpGet("ScreenList")]
        public async Task<IActionResult> GetScreenList(int roleId)
        {

            var data = await _screenService.GetScreenList(roleId);
            return Ok(data);
        }
    }
}
