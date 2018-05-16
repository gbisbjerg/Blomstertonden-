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
        private StatusCatalog _statusCatalog;
        private PaymentTypeCatalog _paymentTypeCatalog;

        private OrderCatalog(OrderFactory factory, string apiId) : base(factory, apiId)
        {
            _statusCatalog = StatusCatalog.Instance;
            _paymentTypeCatalog = PaymentTypeCatalog.Instance;
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

        public PaymentTypeCatalog PaymentTypeCatalog { get => _paymentTypeCatalog; set => _paymentTypeCatalog = value; }
        public StatusCatalog StatusCatalog { get => _statusCatalog; set => _statusCatalog = value; }
    }
}
