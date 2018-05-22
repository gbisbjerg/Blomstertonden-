using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderedProductFactory : IFactory<OrderedProductTData, OrderedProduct>
    {
        public OrderedProduct Convert(OrderedProductTData data)
        {
            throw new NotImplementedException();
        }
    }
}
