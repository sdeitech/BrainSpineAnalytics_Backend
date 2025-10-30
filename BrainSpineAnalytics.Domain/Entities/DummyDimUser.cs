using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_user")]
    public class DummyDimUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("role_id")]
        public int? RoleId { get; set; }

        [Column("clinic_id")]
        public int? ClinicId { get; set; }

        [ForeignKey("RoleId")]
        public DummyDimUserRole Role { get; set; }

        [ForeignKey("ClinicId")]
        public DummyDimClinic Clinic { get; set; }
    }



}
