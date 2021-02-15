using Core.DataObjects.Business.Requests;
using Core.Interfaces.Services;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.LogicServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductTable>> AddProductAsync(params AddProductRequest[] products);
        Task UpdateProductAsync(params UpdateProductRequest[] products);
        Task<IEnumerable<ProductTable>> GetProducts();
        Task<IEnumerable<ProductTable>> GetProductByProductCode(string productCode);
        Task<IEnumerable<ProductTable>> GetProductById(long productId);
        Task<IEnumerable<ProductTable>> GetAllProductsAsync();
    }
}
