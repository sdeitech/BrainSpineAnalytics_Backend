using BrainSpineAnalytics.Application.DTOs.RequestDTOs.RevenueDto;
using System.Collections.Generic;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Revenue
{
    public interface IRevenueService
    {
        List<RevenueFactDto> GetRevenueByUser(string username);
    }
}
