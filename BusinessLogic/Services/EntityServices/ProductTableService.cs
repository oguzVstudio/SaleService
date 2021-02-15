using Core.Interfaces.Services;
using Core.Interfaces.UnitOfWork;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.EntityServices
{
    public class ProductTableService : IProductTableService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductTableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductTable>> AddProductAsync(params ProductTable[] products)
        {
            await _unitOfWork.Products.AddAsync(products);
            await _unitOfWork.CommitAsync();
            return products;
        }

        public async Task<IEnumerable<ProductTable>> GetAllProductsAsync()
        {
            return await _unitOfWork.Products.GetAllProductsAsync();
        }

        public async Task<IEnumerable<ProductTable>> GetProductById(long productId)
        {
            return  _unitOfWork.Products.GetProductById(productId);
        }

        public async Task<IEnumerable<ProductTable>> GetProductByProductCode(string productCode)
        {
            return  _unitOfWork.Products.GetProductByProductCode(productCode);
        }

        public async Task<IEnumerable<ProductTable>> GetProducts()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task UpdateProductAsync(params ProductTable[] products)
        {
            _unitOfWork.Products.Update(products);
            await _unitOfWork.CommitAsync();            
        }
    }
}
