using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_fact_appointments")]
    public class DummyFactAppointments
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date_id")]
        public int? DateId { get; set; }

        [Column("clinic_id")]
        public int? ClinicId { get; set; }

        [Column("provider_id")]
        public int? ProviderId { get; set; }

        [Column("slot_type")]
        public string SlotType { get; set; }

        [Column("total_appointments")]
        public int? TotalAppointments { get; set; }

        [Column("no_shows")]
        public int? NoShows { get; set; }

        [Column("cancellations")]
        public int? Cancellations { get; set; }

        [Column("avg_wait_seconds")]
        public int? AvgWaitSeconds { get; set; }

        [ForeignKey("DateId")]
        public DummyDimDate Date { get; set; }

        [ForeignKey("ClinicId")]
        public DummyDimClinic Clinic { get; set; }

        [ForeignKey("ProviderId")]
        public DummyDimProvider Provider { get; set; }
    }

}
