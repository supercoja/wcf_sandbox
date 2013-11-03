using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ProductsService;

namespace ProductsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductsService
    {
        #region ListProducts
        public List<string> ListProducts()
        {
            List<string> productsList = new List<string>();

            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    var products = from product in database.Products
                                   select product.ProductNumber;

                    productsList = products.ToList();
                }
            }
            catch
            {

            }

            return productsList;
        }
        #endregion

        #region GetProduct
        public ProductData GetProduct(string productNumber)
        {
            ProductData _productData = null;

            try
            {
                using (AdventureWorks2012Entities database = new AdventureWorks2012Entities())
                {
                    Product matchingProduct = database.Products.First(p=> String.Compare(p.ProductNumber,productNumber)==0);

                    _productData = new ProductData()
                    {
                        Name = matchingProduct.Name,
                        ProductNumber = matchingProduct.ProductNumber,
                        Color = matchingProduct.Color,
                        ListPrice = matchingProduct.ListPrice
                    };
                }
            }
            catch
            {
            }

            return _productData;
        }
        #endregion

        #region CurrentStockLevel
        public int CurrentStockLeve(string productNumber)
        {
            return 0;
        }
        #endregion
    }
}
