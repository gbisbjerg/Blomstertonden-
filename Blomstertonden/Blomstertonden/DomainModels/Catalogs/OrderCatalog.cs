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
        private Dictionary<int, Status> _statusData;
        public OrderCatalog(OrderFactory factory, string apiId) : base(factory, apiId)
        {
          Load();
          DBSource<Status, int> statusList = new DBSource<Status, int>(AppConfig.ServerURL ,"api");
          _statusData=new Dictionary<int, Status>();
          _statusData = statusList.Load();
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
