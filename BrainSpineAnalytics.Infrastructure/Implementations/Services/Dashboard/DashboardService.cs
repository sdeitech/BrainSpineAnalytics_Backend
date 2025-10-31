using BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Appointments;
using BrainSpineAnalytics.Application.Interfaces.Services.Dashboard;
using BrainSpineAnalytics.Application.Interfaces.Services.Revenue;
using System.Linq;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Services.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IRevenueService _revService;
        private readonly IAppointmentService _apptService;

        public DashboardService(IRevenueService revService, IAppointmentService apptService)
        {
            _revService = revService;
            _apptService = apptService;
        }

        public DashboardSummaryDTO GetDashboardSummary(string username)
        {
            var revenueList = _revService.GetRevenueByUser(username);
            var apptList = _apptService.GetAppointmentsByUser(username);

            return new DashboardSummaryDTO
            {
                TotalRevenue = revenueList.Sum(r => r.Revenue),
                TotalVisits = revenueList.Sum(r => r.Visits),
                TotalAppointments = apptList.Sum(a => a.TotalAppointments),
                NoShows = apptList.Sum(a => a.NoShows),
                Cancellations = apptList.Sum(a => a.Cancellations)
            };
        }

    }
}
