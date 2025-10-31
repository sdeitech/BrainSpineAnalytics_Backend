using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Screen;
using BrainSpineAnalytics.Application.Interfaces.Repositories.Screen;
using BrainSpineAnalytics.Application.Interfaces.Services.Screen;
using BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Screen
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepo _screenRepo;
        public ScreenService(IScreenRepo screenRepo)
        {
            _screenRepo = screenRepo;
        }
        public Task<List<ScreenListDto>> GetScreenList(int roleId)
        {
            return  _screenRepo.GetScreenListAsync(roleId);
          
        }
    }
}
