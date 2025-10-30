using BrainSpineAnalytics.Application.Dtos.Requests.Revenue;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Revenue
{
 public interface IRevenueRepo
 {
 List<RevenueFactDto> GetRevenue(int? clinicId);
 }
}
