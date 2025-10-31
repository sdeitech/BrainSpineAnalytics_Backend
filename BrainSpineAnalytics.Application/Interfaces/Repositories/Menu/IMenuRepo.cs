using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Menu
{
    public interface IMenuRepo
    {
        Task<List<MenuListDTO>> GetMenu();
    }
}
