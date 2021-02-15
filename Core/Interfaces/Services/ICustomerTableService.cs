using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ICustomerTableService
    {
        Task<CustomerTable> AddCustomer(CustomerTable customer);
        Task<IEnumerable<CustomerTable>> GetCustomerByPhone(string phoneNumber);
        Task<CustomerTable> GetCustomerById(int customerId);
    }
}
