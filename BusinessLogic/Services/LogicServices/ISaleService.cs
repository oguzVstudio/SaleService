using Core.DataObjects.Business.Requests;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.LogicServices
{
    public interface ISaleService
    {
        Task<SalesTable> CreateSaleAsync(CreateSaleRequest saleRequest);
        Task<IEnumerable<SalesTable>> GetSales();
        Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId);
        Task UpdateSaleAsync(CreateSaleRequest saleRequest);
    }
}
