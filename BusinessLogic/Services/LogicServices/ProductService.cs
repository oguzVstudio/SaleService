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
    public class ProductService : IProductService
    {
        private readonly IProductTableService _productTableService;

        public ProductService(IProductTableService productTableService)
        {
            _productTableService = productTableService;
        }

        public async Task<IEnumerable<ProductTable>> AddProductAsync(params AddProductRequest[] products)
        {
            try
            {
                var productValidator = new ProductValidator();
                var productList = new List<ProductTable>();
                foreach (var product in products)
                {
                    var validation = productValidator.Validate(product);                    
                    if (validation.IsValid)
                    {
                        var _product =  _productTableService.GetProductByProductCode(product.ProductCode).Result.ToList();                        
                        if (_product.Count==0)
                        {
                            var createdProduct = await _productTableService.AddProductAsync(new ProductTable()
                            {
                                Barcode = product.Barcode,
                                CreatedBy = product.CreatedBy,
                                CreatedDate = product.CreatedDate,
                                Description = product.Description,
                                IsDeleted = false,
                                ModifiedBy = product.ModifiedBy,
                                ModifiedDate = product.ModifiedDate,
                                ProductCode = product.ProductCode,
                                ProductName = product.ProductName,
                                Price = product.RetailPrice,
                                Stock = product.Quantity
                            });

                            productList.Add(createdProduct.First());
                        }
                        else
                        {
                            foreach (var item in _product)
                            {
                                item.Barcode = product.Barcode;
                                item.Description = product.Description;
                                item.ModifiedBy = product.ModifiedBy;
                                item.ModifiedDate = product.ModifiedDate;
                                item.ProductName = product.ProductName;
                                item.Stock = product.Quantity;
                                item.Price = product.RetailPrice;
                            }

                            await _productTableService.UpdateProductAsync(_product.ToArray());

                            productList.Add(_product.FirstOrDefault());
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
                }

                return productList;
            }
            catch (Exception _ex)
            {

                throw _ex;
            }
        }

        public async Task<IEnumerable<ProductTable>> GetAllProductsAsync()
        {
            return await _productTableService.GetAllProductsAsync();
        }

        public async Task<IEnumerable<ProductTable>> GetProductById(long productId)
        {
            return await _productTableService.GetProductById(productId);
        }

        public async Task<IEnumerable<ProductTable>> GetProductByProductCode(string productCode)
        {
            return await _productTableService.GetProductByProductCode(productCode);
        }

        public async Task<IEnumerable<ProductTable>> GetProducts()
        {
            return await _productTableService.GetProducts();
        }        

        public Task UpdateProductAsync(params UpdateProductRequest[] products)
        {
            throw new NotImplementedException();
        }
    }
}
