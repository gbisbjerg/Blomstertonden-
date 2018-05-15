using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderCatalog : AppCatalogBase<Order, OrderTData, int>
    {
        private static OrderCatalog _instance;
        public OrderCatalog(OrderFactory factory, string apiId) : base(factory, apiId)
        {
          Load();
        }
        public static OrderCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderCatalog(new OrderFactory(), "Orders");
                }
                return _instance;
            }
        }
    }
}
