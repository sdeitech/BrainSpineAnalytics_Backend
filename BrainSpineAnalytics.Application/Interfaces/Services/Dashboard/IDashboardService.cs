using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Dashboard
{
    public interface IDashboardService
    {
        object GetDashboardSummary(string username);
     
    }
}
