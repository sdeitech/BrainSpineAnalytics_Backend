using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Health
{
 [ApiController]
 [Route("api123/[controller]")]
 public class HealthController : ControllerBase
 {
 [HttpGet]
 [AllowAnonymous]
 public IActionResult Get() => Ok(new { status = "Healthy", timeUtc = DateTime.UtcNow });
 }
}
