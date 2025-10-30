using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_user_role")]
    public class DummyDimUserRole
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("role_code")]
        public string RoleCode { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
