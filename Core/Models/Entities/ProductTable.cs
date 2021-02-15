using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Entities
{
    [Table("ProductTable", Schema = "dbo")]
    public class ProductTable
    {
        [Key]
        public long Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        [MaxLength(20)]
        public string Barcode { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [MaxLength(20)]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        [MaxLength(20)]
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
