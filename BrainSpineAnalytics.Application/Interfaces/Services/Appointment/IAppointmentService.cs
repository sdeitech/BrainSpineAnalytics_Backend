using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Services.Appointment
{
    public interface IAppointmentService
    {
        List<AppointmentFact> GetAppointmentsByUser(string username);
    }
}
