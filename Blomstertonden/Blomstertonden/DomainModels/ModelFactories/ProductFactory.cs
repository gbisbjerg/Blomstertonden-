using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductFactory : IFactory<ProductTData, Product>
    {
        public Product Convert(ProductTData data)
        {
            Product obj = new Product()
            {

                Id = data.Key,
                Name = data.Name,
                Price = data.Price,
                IsPromational = data.IsPromational,
                FK_Category = data.FK_Category

            };
            return obj;
        }
    }
}
