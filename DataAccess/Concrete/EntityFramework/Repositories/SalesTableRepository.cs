using Core.Interfaces.Repositories;
using Core.Interfaces.Repositories.Base;
using Core.Models.Entities;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class SalesTableRepository : Repository<SalesTable>, ISalesTableRepository
    {
        public SalesTableRepository(ApplicationDbContext context) : base(context)
        {
        }

        private ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

        public async Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId)
        {
            var result = ApplicationDbContext.Sales
                .Include(u=>u.SaleDetails)                
                .Where(u => u.Id == saleId);

            return result;
        }

        public async Task<IEnumerable<SalesTable>> GetAllSalesAsync()
        {
            var result = await ApplicationDbContext.Sales
                .Include(u => u.SaleDetails)
                .Include(x => x.SaleDetails.Select(y => y.Product))
                .Include(u=>u.Customer)
                .ToListAsync();

            return result;
                
        }
    }
}
