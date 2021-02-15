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
    public class CustomerService : ICustomerTableService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerTable> AddCustomer(CustomerTable customer)
        {
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CommitAsync();
            return customer;
        }

        public async Task<CustomerTable> GetCustomerById(int customerId)
        {
            return await _unitOfWork.Customers.SingleOrDefaultAsync(u => u.Id == customerId);
        }

        public async Task<IEnumerable<CustomerTable>> GetCustomerByPhone(string phoneNumber)
        {
            return _unitOfWork.Customers.Find(u => u.PhoneNumber == phoneNumber);
        }
    }
}
