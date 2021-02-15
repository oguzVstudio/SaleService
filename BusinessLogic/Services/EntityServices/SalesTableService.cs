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
    public class SalesTableService : ISalesTableService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalesTableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SalesTable> CreateSaleAsync(SalesTable salesTable)
        {
            await _unitOfWork.Sales.AddAsync(salesTable);
            await _unitOfWork.CommitAsync();
            return salesTable;
        }

        public async Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId)
        {
            return await _unitOfWork.Sales.GetSaleBySaleId(saleId);
        }

        public async Task<IEnumerable<SalesTable>> GetSales()
        {
            return await _unitOfWork.Sales.GetAllSalesAsync();
        }

        public async Task UpdateSaleAsync(SalesTable salesTable)
        {
            _unitOfWork.Sales.Update(salesTable);
            await _unitOfWork.CommitAsync();
        }
    }
}
