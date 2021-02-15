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
    public class UserTableService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserTableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserTable> FindByIdAsync(int id)
        {
            return await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserTable> FindByUserNameAsync(string username)
        {
            return await _unitOfWork.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }
    }
}
