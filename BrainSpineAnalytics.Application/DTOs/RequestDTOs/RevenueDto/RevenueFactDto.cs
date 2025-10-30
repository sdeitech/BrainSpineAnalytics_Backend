using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Dtos.Requests.Revenue
{
    public class RevenueFactDto
    {
        public int Id { get; set; }
        public string ClinicName { get; set; } = string.Empty;
        public string ProviderName { get; set; } = string.Empty;
        public string PayerName { get; set; } = string.Empty;
        public string ProcedureName { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public int Visits { get; set; }
    }
}
