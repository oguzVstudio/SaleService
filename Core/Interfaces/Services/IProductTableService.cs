using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IProductTableService
    {
        Task<IEnumerable<ProductTable>> AddProductAsync(params ProductTable[] products);        
        Task UpdateProductAsync(params ProductTable[] products);
        Task<IEnumerable<ProductTable>> GetProducts();
        Task<IEnumerable<ProductTable>> GetProductByProductCode(string productCode);
        Task<IEnumerable<ProductTable>> GetProductById(long productId);
        Task<IEnumerable<ProductTable>> GetAllProductsAsync();
    }
}
