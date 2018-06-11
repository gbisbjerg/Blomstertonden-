using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderedProductFactory : IFactory<OrderedProductTData, OrderedProduct>
    {
        public OrderedProduct Convert(OrderedProductTData data)
        {
            OrderedProduct obj = new OrderedProduct
            {
                FK_Order = data.FK_Order,
                FK_Product = data.FK_Product,
                Quantity = data.Quantity
            };
            return obj;
        }
    }
}
