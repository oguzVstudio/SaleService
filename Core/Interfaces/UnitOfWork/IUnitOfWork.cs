using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerTableRepository Customers { get; }
        IProductTableRepository Products { get; }
        ISaleDetailTableRepository SaleDetails { get; }
        ISalesTableRepository Sales { get; }
        IUserTableRepository Users { get; }
        Task<int> CommitAsync();
    }
}
