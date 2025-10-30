using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_payer")]
    public class DummyDimPayer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("payer_code")]
        public string PayerCode { get; set; }

        [Column("payer_name")]
        public string PayerName { get; set; }
    }
}
