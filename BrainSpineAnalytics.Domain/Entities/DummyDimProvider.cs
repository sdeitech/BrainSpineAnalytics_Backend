using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_provider")]
    public class DummyDimProvider
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("provider_code")]
        public string ProviderCode { get; set; }

        [Column("provider_name")]
        public string ProviderName { get; set; }

        [Column("specialty")]
        public string Specialty { get; set; }

        [Column("clinic_id")]
        public int? ClinicId { get; set; }

        [ForeignKey("ClinicId")]
        public DummyDimClinic Clinic { get; set; }
    }
}
