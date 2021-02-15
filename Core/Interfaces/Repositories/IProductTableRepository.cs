using Core.Interfaces.Repositories.Base;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IProductTableRepository : IRepository<ProductTable>
    {
        IEnumerable<ProductTable> GetProductByProductCode(string productCode);
        IEnumerable<ProductTable> GetProductById(long productId);
        Task<IEnumerable<ProductTable>> GetAllProductsAsync();
    }
}
