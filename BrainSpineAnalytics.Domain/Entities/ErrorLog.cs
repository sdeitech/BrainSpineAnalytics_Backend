using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("ErrorLogs")]
    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string? InnerException { get; set; }
        public string? Source { get; set; }
        public string? Path { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
