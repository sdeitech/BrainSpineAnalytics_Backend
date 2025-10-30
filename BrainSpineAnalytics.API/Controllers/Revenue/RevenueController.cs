using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Revenue
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _service;

        public RevenueController(IRevenueService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string username)
        {
            var data = _service.GetRevenueByUser(username);
            return Ok(data);
        }
    }
}
