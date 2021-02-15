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
    public class SaleDetailService : ISaleDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SaleDetailTable>> CreateSaleDetailsAsync(params SaleDetailTable[] saleDetailTable)
        {
            await _unitOfWork.SaleDetails.AddAsync(saleDetailTable);
            await _unitOfWork.CommitAsync();
            return saleDetailTable;
        }
    }
}
