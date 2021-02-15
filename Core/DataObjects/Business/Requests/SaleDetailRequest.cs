using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataObjects.Business.Requests
{
    public class SaleDetailRequest
    {
        public int LineNo { get; set; }
        public long ProductId { get; set; }
        public double SalesPrice { get; set; }
        public int Quantity { get; set; }        
    }
}
