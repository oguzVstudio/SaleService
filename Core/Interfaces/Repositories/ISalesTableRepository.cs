using Core.Interfaces.Repositories.Base;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ISalesTableRepository : IRepository<SalesTable>
    {
        Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId);
        Task<IEnumerable<SalesTable>> GetAllSalesAsync();
    }
}
