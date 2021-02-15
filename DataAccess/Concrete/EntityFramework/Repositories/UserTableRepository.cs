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

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserTableRepository : Repository<UserTable>, IUserTableRepository
    {
        public UserTableRepository(ApplicationDbContext context) : base(context)
        {
        }

        private ApplicationDbContext ApplicationDbContext => Context as ApplicationDbContext;

    }
}
