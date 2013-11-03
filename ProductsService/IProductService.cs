using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ProductsService
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string ProductNumber;

        [DataMember]
        public string Color;

        [DataMember]
        public decimal ListPrice;
    }

    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        List<string> ListProducts();

        [OperationContract]
        ProductData GetProduct(string productNumber);

        [OperationContract]
        int CurrentStockLevel(string productNumber);

        [OperationContract]
        bool ChangeStockLevel(string productNumber, short newStockLevel, string shelf, int bin);
    }
}
