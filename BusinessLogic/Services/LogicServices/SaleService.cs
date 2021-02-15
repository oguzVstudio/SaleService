using BusinessLogic.Validators;
using Core.DataObjects.Business.Requests;
using Core.Interfaces.Services;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.LogicServices
{
    public class SaleService : ISaleService
    {
        private readonly ISalesTableService _salesTableService;
        private readonly ISaleDetailService _saleDetailService;
        private readonly IProductTableService _productTableService;

        public SaleService(ISalesTableService salesTableService, ISaleDetailService saleDetailService, IProductTableService productTableService)
        {
            _saleDetailService = saleDetailService;
            _salesTableService = salesTableService;
            _productTableService = productTableService;
        }
        public async Task<SalesTable> CreateSaleAsync(CreateSaleRequest saleRequest)
        {
            try
            {
                var saleValidator = new CreateSaleValidator();
                SalesTable createdSale = null;
                var validation = saleValidator.Validate(saleRequest);
                if (validation.IsValid)
                {
                    var sale = await _salesTableService.CreateSaleAsync(new SalesTable()
                    {
                        CustomerId = saleRequest.CustomerId,
                        Quantity = saleRequest.Quantity,
                        SaleDate = saleRequest.SaleDate,
                        SalesPrice = saleRequest.SalesPrice
                    });

                    if(sale != null)
                    {
                        createdSale = sale;
                        foreach (var saleDetail in saleRequest.SaleDetails)
                        {
                            var createdLine = await _saleDetailService.CreateSaleDetailsAsync(new SaleDetailTable()
                            {
                                LineNo = saleDetail.LineNo,
                                ProductId = saleDetail.ProductId,
                                Quantity = saleDetail.Quantity,
                                SaleId = sale.Id,
                                SalesPrice = saleDetail.SalesPrice
                            });

                            //var product = createdLine.FirstOrDefault().Product;
                            var pId = createdLine.FirstOrDefault().ProductId;
                            var products = _productTableService.GetProductById(pId).Result;
                            var product = products.FirstOrDefault();
                            var stock = product.Stock;
                            if(stock == 0)
                            {
                                throw new Exception("There is not enough stock");
                            }
                            product.Stock -= saleDetail.Quantity;                            
                            await _productTableService.UpdateProductAsync(product);
                        }
                    }
                }
                else
                {
                    var errors = validation.Errors;
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in errors)
                    {
                        sb.AppendLine(error.ErrorMessage);
                    }
                    throw new Exception(sb.ToString());
                }

                return createdSale;
            }
            catch (Exception _ex)
            {

                throw _ex;
            }
        }

        public async Task<IEnumerable<SalesTable>> GetSaleBySaleId(long saleId)
        {
            return await _salesTableService.GetSaleBySaleId(saleId);
        }

        public async Task<IEnumerable<SalesTable>> GetSales()
        {
            return await _salesTableService.GetSales();
        }

        public async Task UpdateSaleAsync(CreateSaleRequest saleRequest)
        {
            throw new NotImplementedException();
        }
    }
}
