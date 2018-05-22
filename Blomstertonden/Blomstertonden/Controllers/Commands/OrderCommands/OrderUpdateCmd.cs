using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderUpdateCmd : UpdateCommandBase<OrderTData, Order, int>
    {
        CustomerCatalog _customerCatalog;
        public OrderUpdateCmd(ICRUD<Order, OrderTData, int> catalog, MasterDetailsViewModelBase<OrderTData, Order, int> viewModel) : base(catalog, viewModel)
        {
            _customerCatalog = CustomerCatalog.Instance;
        }
        public async override void Execute()
        {
            await _catalog.Update(_catalog.DataPackage);
            _customerCatalog.DataPackage.Key = _catalog.DataPackage.FK_Customer;
            await _customerCatalog.Update(_customerCatalog.DataPackage);

            await _customerCatalog.LocalCreate(_customerCatalog.DataPackage.Key);
            await _catalog.LocalCreate(_catalog.DataPackage.Key);


            ExecuteEvent();
        }
    }
}
