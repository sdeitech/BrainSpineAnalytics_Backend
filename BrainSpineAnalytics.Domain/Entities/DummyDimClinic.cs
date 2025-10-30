using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_clinic")]
    public class DummyDimClinic
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("clinic_code")]
        public string ClinicCode { get; set; }

        [Column("clinic_name")]
        public string ClinicName { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }
    }
}
