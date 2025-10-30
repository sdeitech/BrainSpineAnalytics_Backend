using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Dashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [Authorize]
        [HttpGet("dashboard")]
        public IActionResult Get([FromQuery] string username)
        {
            var data = _dashboardService.GetDashboardSummary(username);
            return Ok(data);
        }

    }
}
