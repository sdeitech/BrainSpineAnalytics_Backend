using BrainSpineAnalytics.Application.Interfaces.Repositories.Appointment;
using BrainSpineAnalytics.Domain.Entities;
using BrainSpineAnalytics.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment.AppointmentRepo;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.Appointment
{

        public class AppointmentRepo : IAppointmentRepo
        {
            private readonly BrainSpineDBContext _context;

            public AppointmentRepo(BrainSpineDBContext context)
            {
                _context = context;
            }

        public List<AppointmentFact> GetAppointments(int? clinicId)
        {
            var query = _context.DummyFactAppointments.AsQueryable();

            // ✅ Apply the filter BEFORE projection
            if (clinicId.HasValue)
                query = query.Where(f => f.ClinicId == clinicId.Value);

            // ✅ Then project to DTO
            var result = query.Select(f => new AppointmentFact
            {
                Id = f.Id,
                ClinicName = f.Clinic != null ? f.Clinic.ClinicName : "",
                ProviderName = f.Provider != null ? f.Provider.ProviderName : "",
                SlotType = f.SlotType,
                TotalAppointments = f.TotalAppointments ?? 0, // Fix: handle nullable int
                NoShows = f.NoShows ?? 0,                    // Fix: handle nullable int
                Cancellations = f.Cancellations ?? 0,        // Fix: handle nullable int
                AvgWaitSeconds = f.AvgWaitSeconds ?? 0       // Fix: handle nullable int
            }).ToList();

            return result;
        }

    }
}


