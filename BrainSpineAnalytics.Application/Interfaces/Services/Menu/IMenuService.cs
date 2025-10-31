using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Menu
{
    public interface IMenuService
    {
        Task<List<MenuListDTO>> GetMenuList(int roleId);
    }
}
