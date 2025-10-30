using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_procedure")]
    public class DummyDimProcedure
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("procedure_code")]
        public string ProcedureCode { get; set; }

        [Column("procedure_name")]
        public string ProcedureName { get; set; }

        [Column("category")]
        public string Category { get; set; }
    }

}
