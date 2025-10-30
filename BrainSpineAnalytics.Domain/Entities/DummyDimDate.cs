using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSpineAnalytics.Domain.Entities
{
    [Table("dummy_dim_date")]
    public class DummyDimDate
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dt")]
        public DateTime Date { get; set; }

        [Column("day")]
        public int? Day { get; set; }

        [Column("month")]
        public int? Month { get; set; }

        [Column("year")]
        public int? Year { get; set; }

        [Column("month_name")]
        public string MonthName { get; set; }
    }
}
