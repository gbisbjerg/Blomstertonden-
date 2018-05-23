using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GenericsLibrary;

namespace Blomstertonden
{
    class ClearDataPackagesCmd : ICommand
    {
        CustomerCatalog _customerCatalog;
        OrderCatalog _orderCatalog;
        ProductCatalog _productCatalog;
        OrderedProductCatalog _orderedProductCatalog;
        public ClearDataPackagesCmd()
        {
            _customerCatalog = CustomerCatalog.Instance;
            _orderCatalog = OrderCatalog.Instance;
            _productCatalog = ProductCatalog.Instance;
            _orderedProductCatalog = OrderedProductCatalog.Instance;
           
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _customerCatalog.DataPackage = new CustomerTData();
            _orderCatalog.DataPackage = new OrderTData();
            _productCatalog.DataPackage = new ProductTData();
            _orderedProductCatalog.DataPackage = new OrderedProductTData();
            _orderedProductCatalog.OPTDataList = new List<OrderedProductTData>();
        }
    }
}
