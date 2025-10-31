using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Screen
{
    public interface IScreenService
    {
        Task<List<ScreenListDto>> GetScreenList(int roleId);
    }
}
