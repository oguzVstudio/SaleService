using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generali.UI.Models.Sale
{
    public class SaleListModel
    {
        public long SaleId { get; set; }
        public int LineNo { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public string SalesDate { get; set; }
    }
}