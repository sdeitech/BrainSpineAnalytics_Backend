using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Screen
{
    public interface IScreenRepo
    {
        Task<List<ScreenListDto>> GetScreenListAsync(int roleId);
    }
}
