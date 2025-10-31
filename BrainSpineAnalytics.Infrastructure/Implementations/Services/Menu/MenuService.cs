using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Menu;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Menu;
using BrainSpineAnalytics.Application.Interfaces.Services.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo _menuRepo;
        public MenuService(IMenuRepo menuRepo)
        {
            _menuRepo = menuRepo;
        }
        public async Task<List<MenuListDTO>> GetMenu()
        {
          return await _menuRepo.GetMenu();
        } 
    }
}
