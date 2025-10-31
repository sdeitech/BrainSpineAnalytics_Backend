using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Dashboard
{
    public class DashboardSummaryDTO
    {
        public decimal TotalRevenue { get; set; }
        public int TotalVisits { get; set; }
        public int TotalAppointments { get; set; }
        public int NoShows { get; set; }
        public int Cancellations { get; set; }
    }

}
