using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private CustomerTableRepository _customerTableRepository;        
        private ProductTableRepository _productTableRepository;
        private SalesTableRepository _salesTableRepository;
        private SaleDetailTableRepository _saleDetailTableRepository;
        private UserTableRepository _userTableRepository;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICustomerTableRepository Customers => _customerTableRepository ?? new CustomerTableRepository(_context);

        public IProductTableRepository Products => _productTableRepository ?? new ProductTableRepository(_context);

        public ISaleDetailTableRepository SaleDetails => _saleDetailTableRepository ?? new SaleDetailTableRepository(_context);

        public ISalesTableRepository Sales => _salesTableRepository ?? new SalesTableRepository(_context);

        public IUserTableRepository Users => _userTableRepository ?? new UserTableRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
