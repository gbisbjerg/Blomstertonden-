using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderFactory : IFactory<OrderTData, Order>
    {
        public Order Convert(OrderTData data)
        {
            throw new NotImplementedException();
        }
    }
}
