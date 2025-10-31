using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("HeaderSubHeaderRoleMapping")]
    public class HeaderSubHeaderRoleMapping
    {
       
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MappingId { get; set; }
        public bool CanView { get; set; } = true;
        public bool CanEdit { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
