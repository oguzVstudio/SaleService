using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ISalesTableService
    {
        Task<SalesTable> CreateSaleAsync(SalesTable salesTable);
        Task<IEnumerable<SalesTable>> GetSales();
        Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId);
        Task UpdateSaleAsync(SalesTable salesTable);
    }
}
