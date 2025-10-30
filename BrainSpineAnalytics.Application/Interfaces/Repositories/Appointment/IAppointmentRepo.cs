using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.Appointment
{
    public interface IAppointmentRepo
    {
        List<AppointmentFact> GetAppointments(int? clinicId);
    }
}
