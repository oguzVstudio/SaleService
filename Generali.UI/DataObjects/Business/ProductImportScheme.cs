using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generali.UI.DataObjects.Business
{
    public class ProductImportScheme
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public decimal RetailPrice { get; set; }
        public double Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}