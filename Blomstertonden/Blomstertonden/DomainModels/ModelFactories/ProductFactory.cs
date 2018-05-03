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
            throw new NotImplementedException();
        }
    }
}
