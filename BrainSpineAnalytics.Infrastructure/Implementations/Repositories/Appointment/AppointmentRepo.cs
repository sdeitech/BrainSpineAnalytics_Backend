using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointments;
using BrainSpineAnalytics.Domain.Entities;
using BrainSpineAnalytics.Infrastructure.Data;
using System.Linq;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly BrainSpineDbContext _context;
        public AppointmentRepo(BrainSpineDbContext context)
        {
            _context = context;
        }

        public List<AppointmentFact> GetAppointments(int? clinicId)
        {
            var query = _context.DummyFactAppointments.AsQueryable();

            if (clinicId.HasValue)
                query = query.Where(f => f.ClinicId == clinicId.Value);

            var result = query.Select(f => new AppointmentFact
            {
                Id = f.Id,
                ClinicName = f.Clinic != null ? f.Clinic.ClinicName : "",
                ProviderName = f.Provider != null ? f.Provider.ProviderName : "",
                SlotType = f.SlotType,
                TotalAppointments = f.TotalAppointments ?? 0,
                NoShows = f.NoShows ?? 0,
                Cancellations = f.Cancellations ?? 0,
                AvgWaitSeconds = f.AvgWaitSeconds ?? 0
            }).ToList();

            return result;
        }
    }
}


