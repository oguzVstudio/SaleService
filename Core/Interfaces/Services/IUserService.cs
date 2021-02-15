using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserTable> FindByIdAsync(int id);
        Task<UserTable> FindByUserNameAsync(string username);        
    }
}
