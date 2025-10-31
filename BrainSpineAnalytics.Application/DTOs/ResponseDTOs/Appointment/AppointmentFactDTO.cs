using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.DTOs.ResponseDTOs.Appointment
{
    public class AppointmentFactDTO
    {
        public int Id { get; set; }
        public string? ClinicName { get; set; }
        public string? ProviderName { get; set; }
        public string? SlotType { get; set; }
        public int TotalAppointments { get; set; }
        public int NoShows { get; set; }
        public int Cancellations { get; set; }
        public int AvgWaitSeconds { get; set; }
    }
}
