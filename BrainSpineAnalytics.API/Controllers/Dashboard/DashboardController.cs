using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Appointment;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Dashboard;
using BrainSpineAnalytics.Infrastructure.Implementations.Services.Revenue;
using Microsoft.AspNetCore.Http;
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
            //var userRepo = new UserRepository();
            //var revRepo = new RevenueRepository();
            //var apptRepo = new AppointmentRepository();

            //var revService = new RevenueService(userRepo, revRepo);
            //var apptService = new AppointmentService(userRepo, apptRepo);

            _dashboardService = dashboardService;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Get([FromQuery] string username)
        {
            var data = _dashboardService.GetDashboardSummary(username);
            return Ok(data);
        }

    }
}
