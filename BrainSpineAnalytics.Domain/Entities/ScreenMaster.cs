using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
        [Table("ScreenMaster")]
        public class ScreenMaster
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(150)]
            public string ScreenName { get; set; } = string.Empty;

            public string? Description { get; set; }

            public bool IsActive { get; set; } = true;
            public bool IsDeleted { get; set; } = false;

            public int? CreatedBy { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public int? UpdatedBy { get; set; }
            public DateTime? UpdatedAt { get; set; }

            public int? DeletedBy { get; set; }
            public DateTime? DeletedAt { get; set; }

            // Navigation property
            public ICollection<RoleScreenMapping> RoleScreenMappings { get; set; } = new List<RoleScreenMapping>();
        }
    }


