using Core.DataObjects.Business.Requests;
using Core.DataObjects.Business.Responses;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        List<ProductTable> GetProducts();

        [OperationContract]
        List<ProductTable> AddProducts(params AddProductRequest[] addProductRequest);

        [OperationContract]
        SalesTable CreateSale(CreateSaleRequest saleRequest);

        [OperationContract]
        SalesTable GetSale(long saleId);

        [OperationContract]
        List<SalesTable> GetSales();

        [OperationContract]
        LoginResult Login(UserLoginRequest userLoginRequest);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
