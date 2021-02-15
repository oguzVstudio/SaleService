using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataObjects.Business.Requests
{
    public class UpdateProductRequest : AddProductRequest
    {
        public long Id { get; set; }
    }
}
