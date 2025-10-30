using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    public class RevenueFact
    {
        public int Id { get; set; }
        public string ClinicName { get; set; }
        public string ProviderName { get; set; }
        public string PayerName { get; set; }
        public string ProcedureName { get; set; }
        public decimal Revenue { get; set; }
        public int Visits { get; set; }
    }
}
