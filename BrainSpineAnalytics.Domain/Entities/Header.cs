using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("HeaderMaster")]
    public class Header
    {
        public int HeaderId { get; set; }
        public string HeaderName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation
        public ICollection<HeaderSubHeaderMapping> HeaderSubHeaderMappings { get; set; }
    }
}
