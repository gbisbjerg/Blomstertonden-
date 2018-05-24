using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    public class Startup
    {
        public Startup()
        {
            CustomerCatalog customerCatalog = CustomerCatalog.Instance;
            OrderCatalog orderCatalog = OrderCatalog.Instance;
            ProductCatalog productCatalog = ProductCatalog.Instance;
            CategoryCatalog categoryCatalog = CategoryCatalog.Instance;
            OrderedProductCatalog orderedProductCatalog = OrderedProductCatalog.Instance;
            PaymentTypeCatalog paymentType = PaymentTypeCatalog.Instance;
            StatusCatalog statusCatalog = StatusCatalog.Instance;
        }
    }
}
