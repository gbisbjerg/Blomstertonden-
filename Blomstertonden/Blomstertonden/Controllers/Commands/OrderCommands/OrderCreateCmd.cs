using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderCreateCmd : CreateCommandBase<OrderTData, Order, int>
    {
        private CustomerCatalog _customerCatalog;
        public OrderCreateCmd(ICRUD<Order, OrderTData, int> catalog, MasterDetailsViewModelBase<OrderTData, Order, int> viewModel) : base(catalog, viewModel)
        {
            _customerCatalog = CustomerCatalog.Instance;
        }

        public async override void Execute()
        {
             
            _catalog.DataPackage.FK_Customer = await _customerCatalog.Create(_customerCatalog.DataPackage);
            await _catalog.Create(_catalog.DataPackage);

            base.Execute();
        }
    }
}
