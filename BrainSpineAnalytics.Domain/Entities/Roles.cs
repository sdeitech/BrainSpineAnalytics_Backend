using System;
using System.ComponentModel.DataAnnotations;

namespace BrainSpineAnalytics.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
