using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Entities
{
    [Table("SaleDetailTable", Schema = "dbo")]
    public class SaleDetailTable
    {
        [Key]
        public long Id { get; set; }
        public int LineNo { get; set; }
        public long ProductId { get; set; }
        public ProductTable Product { get; set; }
        public double SalesPrice { get; set; }
        public int Quantity { get; set; }
        public long CampaignId { get; set; }        
        public long SaleId { get; set; }
        [ForeignKey(nameof(SalesTable))]
        public SalesTable Sale { get; set; }
    }
}
