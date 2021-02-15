using BusinessLogic.Services.LogicServices;
using Core.DataObjects.Business.Requests;
using Core.DataObjects.Business.Responses;
using Core.Interfaces.Services;
using Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GeneraliSaleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IUserLoginService _userLoginService;
        public Service1(IProductService productService, ISaleService saleService, IUserLoginService userLoginService)
        {
            _productService = productService;
            _saleService = saleService;
            _userLoginService = userLoginService;
        }        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<ProductTable> GetProducts()
        {
            var result = _productService.GetAllProductsAsync().Result.ToList();
            return result;
        }

        public List<ProductTable> AddProducts(params AddProductRequest[] addProductRequest)
        {
            var result = _productService.AddProductAsync(addProductRequest).Result;

            return result.ToList();
        }

        public SalesTable CreateSale(CreateSaleRequest saleRequest)
        {
            var result = _saleService.CreateSaleAsync(saleRequest).Result;
            result.SaleDetails.ForEach(u => u.Sale = null);
            return result;
        }

        public SalesTable GetSale(long saleId)
        {
            var result = _saleService.GetSaleBySaleId(saleId).Result;
            
            return result.FirstOrDefault();
        }

        public List<SalesTable> GetSales()
        {
            var result = _saleService.GetSales().Result;

            foreach (var item in result)
            {
                foreach (var saleDetail in item.SaleDetails)
                {
                    saleDetail.Sale = null;                    
                }
            }

            return result.ToList();
        }

        public LoginResult Login(UserLoginRequest userLoginRequest)
        {
            var result = _userLoginService.LoginAsync(userLoginRequest).Result;

            return result;
        }
    }
}
