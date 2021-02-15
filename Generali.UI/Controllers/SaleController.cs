using Generali.UI.Artifacts;
using Generali.UI.DataObjects.Business;
using Generali.UI.Models.Sale;
using Generali.UI.SalesWCFReference;
using Generali.UI.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF = Generali.UI.SalesWCFReference;

namespace Generali.UI.Controllers
{
    [AuthorizationFilter]
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public JsonResult UploadProduct(HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    var fileStream = file.InputStream;
                    var excelContent = ExcelImporter.ParseExcel(new MemoryStream(ExcelImporter.ReadFully(fileStream)));
                    string json = JsonConvert.SerializeObject(excelContent);
                    var importList = JsonConvert.DeserializeObject<List<ProductImportScheme>>(json);
                    var addProductRequest = new List<AddProductRequest>();
                    
                    int row = 1;
                    foreach (var item in importList)
                    {

                        if (string.IsNullOrEmpty(item.Barcode))
                        {
                            throw new Exception($"Row = {row}, Barcode can not be empty");
                        }
                        else if (string.IsNullOrEmpty(item.Description))
                        {
                            throw new Exception($"Row = {row}, Description can not be empty");
                        }
                        else if (string.IsNullOrEmpty(item.ProductCode))
                        {
                            throw new Exception($"Row = {row}, ProductCode can not be empty");
                        }
                        else if (string.IsNullOrEmpty(item.ProductName))
                        {
                            throw new Exception($"Row = {row}, ProductName can not be empty");
                        }
                        else if (item.RetailPrice<0)
                        {
                            throw new Exception($"Row = {row}, Price can not be lower than 0");
                        }
                        else if (item.Quantity<0)
                        {
                            throw new Exception($"Row = {row}, Quantity can not be lower than 0");
                        }

                        addProductRequest.Add(new AddProductRequest()
                        {
                            Barcode = item.Barcode,
                            CreatedBy = "admin",
                            CreatedDate = DateTime.Now,
                            Description = item.Description,
                            ModifiedBy = "admin",
                            ModifiedDate = DateTime.Now,
                            ProductCode = item.ProductCode,
                            ProductName = item.ProductName,
                            Quantity = (int)item.Quantity,
                            RetailPrice = item.RetailPrice
                        });

                        row++;
                    }

                    WCF.Service1Client client = new WCF.Service1Client();

                    var response = client.AddProducts(addProductRequest.ToArray());

                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false, ErrorMessage = "Please choose file" });
                }
            }
            catch (Exception _ex)
            {

                return Json(new { Success = false, ErrorMessage = _ex.Message });
            }            
        }

        public JsonResult GetSales()
        {
            WCF.Service1Client client = new WCF.Service1Client();
            var saleList = client.GetSales().ToList();
            var model = new List<SaleListModel>();

            foreach (var sale in saleList)
            {
                foreach (var detail in sale.SaleDetails)
                {
                    model.Add(new SaleListModel()
                    {
                        LineNo = detail.LineNo,
                        Price = detail.SalesPrice,
                        ProductCode = detail.Product.ProductCode,
                        ProductName = detail.Product.ProductName,
                        Quantity = detail.Quantity,
                        SaleId = sale.Id,
                        SalesDate = sale.SaleDate.ToString("dd-MM-yyyy")
                    });
                }
            }

            return Json(model, "application/javascript", JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateSale()
        {
            return View();
        }

        public JsonResult SaveSale(List<SaleDetailRequest> saleRequests)
        {
            try
            {
                WCF.Service1Client client = new WCF.Service1Client();
                if (saleRequests == null)
                {
                    saleRequests = new List<SaleDetailRequest>();

                    return Json(new { Success = false, ErrorMessage = "Sipariş satıları alınamadı" });
                }

                var createSaleRequest = new CreateSaleRequest()
                {
                    CustomerId = 1,//default
                    Quantity = saleRequests.Sum(u => u.Quantity),
                    SaleDate = DateTime.Now,
                    SalesPrice = saleRequests.Sum(u => u.SalesPrice),
                    SaleDetails = saleRequests.ToArray()
                };

                var response = client.CreateSale(createSaleRequest);

                if (response != null)
                {
                    return Json(new { Success = true });
                }
                else
                {
                    return Json(new { Success = false, ErrorMessage = "Bir hata oluştu" });
                }
            }
            catch (Exception _ex)
            {

                return Json(new { Success = false, ErrorMessage = "Bir hata oluştu" });
            }
        }

        public JsonResult GetProducts()
        {
            try
            {
                WCF.Service1Client client = new WCF.Service1Client();

                var products = client.GetProducts();

                var data = products.Select(u => new
                {
                    ProductId = u.Id,
                    ProductName = u.ProductName,
                    Stock = u.Stock,
                    Price = u.Price
                });

                return Json(new { Data = data, Success = true });
            }
            catch (Exception)
            {

                return Json(new { Success = false });
            }            
        }
    }
}