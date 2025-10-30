using BrainSpineAnalytics.Application.DTOs.RequestDTOs.RevenueDto;
using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue
{
    public interface IRevenueRepo
    {
        List<RevenueFactDto> GetRevenue(int? clinicId);
    }
}
