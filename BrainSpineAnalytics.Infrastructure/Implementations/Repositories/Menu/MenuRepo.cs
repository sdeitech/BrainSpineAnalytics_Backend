using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Menu;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Menu;
using BrainSpineAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Menu
{
    public class MenuRepo : IMenuRepo
    {
        private readonly BrainSpineDbContext _context;
        public MenuRepo(BrainSpineDbContext context)
        {
         _context = context;
        }


        public async Task<List<MenuListDTO>> GetMenu()
        {
            var menuItems = await(
                           from map in _context.HeaderSubHeaderMappings 
                           join header in _context.Headers on map.HeaderId equals header.HeaderId
                           join sub in _context.SubHeaders on map.SubHeaderId equals sub.SubHeaderId
                           where !map.IsDeleted
                           orderby header.DisplayOrder, map.DisplayOrder
                           select new MenuListDTO
                           {
                               HeaderName = header.HeaderName,
                               SubHeaderName = sub.SubHeaderName,
                               RouteUrl = sub.RouteUrl,
                               Icon = sub.Icon,
                               DisplayOrder = map.DisplayOrder
                           }).ToListAsync();

            return menuItems;
        }
    }
}
