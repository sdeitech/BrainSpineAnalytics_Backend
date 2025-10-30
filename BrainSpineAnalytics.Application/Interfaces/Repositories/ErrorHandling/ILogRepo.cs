using BrainSpineAnalytics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Application.Interfaces.Repositories.ErrorHandling
{
    public interface ILogRepo
    {
        Task<int> LogErrorAsync(ErrorLog errorLog);
    }
}
