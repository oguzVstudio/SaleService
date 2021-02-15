using Core.Interfaces.Repositories;
using Core.Models.Entities;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class ProductTableRepository : Repository<ProductTable>, IProductTableRepository
    {
        public ProductTableRepository(ApplicationDbContext context) : base(context)
        {
        }

        private ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public IEnumerable<ProductTable> GetProductById(long productId)
        {
            var result = ApplicationDbContext.Products
                .Where(u=>u.Id == productId && u.IsDeleted == false).ToList();

            return result;
        }

        public IEnumerable<ProductTable> GetProductByProductCode(string productCode)
        {
            var result = ApplicationDbContext.Products
                .Where(u => u.ProductCode == productCode && u.IsDeleted == false).ToList();

            return result;
        }

        public async Task<IEnumerable<ProductTable>> GetAllProductsAsync()
        {
            var res = await ApplicationDbContext.Products
                .Where(u => u.IsDeleted == false).ToListAsync();

            return res;
        }
    }
}
