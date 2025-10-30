using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_fact_revenue")]
    public class DummyFactRevenue
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

        [Column("payer_id")]
        public int? PayerId { get; set; }

        [Column("procedure_id")]
        public int? ProcedureId { get; set; }

        [Column("revenue")]
        public decimal? Revenue { get; set; }

        [Column("visits")]
        public int? Visits { get; set; }

        [ForeignKey("DateId")]
        public DummyDimDate Date { get; set; }

        [ForeignKey("ClinicId")]
        public DummyDimClinic Clinic { get; set; }

        [ForeignKey("ProviderId")]
        public DummyDimProvider Provider { get; set; }

        [ForeignKey("PayerId")]
        public DummyDimPayer Payer { get; set; }

        [ForeignKey("ProcedureId")]
        public DummyDimProcedure Procedure { get; set; }
    }


}
