using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    
        [Table("RoleScreenMapping")]
        public class RoleScreenMapping
        {
            [Key]
            public int Id { get; set; }

            [ForeignKey(nameof(Role))]
            public int RoleId { get; set; }

            [ForeignKey(nameof(Screen))]
            public int ScreenId { get; set; }

            public bool CanView { get; set; } = true;
            public bool CanEdit { get; set; } = false;
            public bool IsActive { get; set; } = true;
            public bool IsDeleted { get; set; } = false;

            public int? CreatedBy { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            public int? UpdatedBy { get; set; }
            public DateTime? UpdatedAt { get; set; }

            public int? DeletedBy { get; set; }
            public DateTime? DeletedAt { get; set; }

            // Navigation properties
            public Role Role { get; set; }
            public ScreenMaster Screen { get; set; }
        }
    }


