using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrainSpineAnalytics.API.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpGet("Menu")]
        public async  Task<IActionResult> Get(int roleId)
        {

            var data = await _menuService.GetMenuList(roleId);
            return Ok(data);
        }


    }
}
