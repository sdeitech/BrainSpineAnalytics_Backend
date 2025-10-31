using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("UserRoleMapping")]
    public class UserRoleMapping
    {
        [Key]
        public int UserRoleMappingId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;
    }
}
