using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductCatalog : AppCatalogBase<Product, ProductTData, int>
    {
        private static ProductCatalog _instance;

        public ProductCatalog(ProductFactory factory, string apiId) : base(factory, apiId)
        {
        }

        public static ProductCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductCatalog(new ProductFactory(), "Products");
                }
                return _instance;
            }
        }
    }
}
