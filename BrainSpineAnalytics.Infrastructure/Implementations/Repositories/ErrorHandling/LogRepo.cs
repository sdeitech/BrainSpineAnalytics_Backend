using BrainSpineAnalytics.Application.Interfaces.Repositories.ErrorHandling;
using BrainSpineAnalytics.Domain.Entities;
using BrainSpineAnalytics.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Infrastructure.Implementations.Repositories.ErrorHandling
{
    public class LogRepo : ILogRepo
    {
            private readonly BrainSpineDbContext _context;
        private readonly ILogger<LogRepo> _logger;

        public LogRepo(BrainSpineDbContext context, ILogger<LogRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> LogErrorAsync(ErrorLog errorLog)
        {
            try
            {
                _context.ErrorLogs.Add(errorLog);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // If DB logging fails, still log it via ILogger
                _logger.LogError(ex, "Failed to save error log to database.");
                return 0;
            }
        
    
}
    }

    
}
