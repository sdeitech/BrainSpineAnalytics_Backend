using BrainSpineAnalytics.Application.Interfaces.Services.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Appointment
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string username)
        {
            var data = _service.GetAppointmentsByUser(username);
            return Ok(data);
        }
    }
}
