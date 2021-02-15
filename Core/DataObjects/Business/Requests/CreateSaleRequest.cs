using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataObjects.Business.Requests
{
    public class CreateSaleRequest
    {
        public double SalesPrice { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public List<SaleDetailRequest> SaleDetails { get; set; }
    }
}
