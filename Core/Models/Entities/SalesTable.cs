using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Entities
{
    [Table("SalesTable", Schema = "dbo")]
    public class SalesTable
    {
        [Key]
        public long Id { get; set; }
        public double SalesPrice { get; set; }
        public DateTime SaleDate { get; set; }
        public double Quantity { get; set; }        
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public CustomerTable Customer { get; set; }
        public List<SaleDetailTable> SaleDetails { get; set; }
    }
}
