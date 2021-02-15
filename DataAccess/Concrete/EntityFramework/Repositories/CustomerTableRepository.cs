using Core.Interfaces.Repositories;
using Core.Models.Entities;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Concrete.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class CustomerTableRepository : Repository<CustomerTable>, ICustomerTableRepository
    {
        public CustomerTableRepository(ApplicationDbContext context) : base(context)
        {
        }

        private ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

    }
}
