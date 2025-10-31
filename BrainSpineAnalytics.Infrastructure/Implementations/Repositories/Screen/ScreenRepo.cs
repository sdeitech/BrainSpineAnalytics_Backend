using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Screen;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Screen;
using BrainSpineAnalytics.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Screen
{
    public class ScreenRepo : IScreenRepo
    {
        private readonly BrainSpineDbContext _brainSpineDbContext;
        public ScreenRepo(BrainSpineDbContext brainSpineDbContext)
        {
            _brainSpineDbContext = brainSpineDbContext;
        }

        public async Task<List<ScreenListDto>> GetScreenListAsync(int roleId)
        {
            var result = await (
                from s in _brainSpineDbContext.ScreenMasters
                join m in _brainSpineDbContext.RoleScreenMappings on s.Id equals m.ScreenId
                join r in _brainSpineDbContext.Roles on m.RoleId equals r.RoleId
                where
                    s.IsActive && !s.IsDeleted &&
                    m.IsActive && !m.IsDeleted &&
                    r.IsActive && !r.IsDeleted &&
                     m.RoleId == roleId

                select new ScreenListDto
                {
                    RoleId = r.RoleId,
                    RoleName=r.Name,
                    ScreenId = s.Id,
                    ScreenName = s.ScreenName

                }
            ).ToListAsync();

            return result;
        }

    }
}
