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

        public override async void Execute()
        {
            if (_customerCatalog.DataPackage.Key != 0)
            {
                _catalog.DataPackage.FK_Customer = await _customerCatalog.Create(_customerCatalog.DataPackage);
            }
            else
            {
                _catalog.DataPackage.FK_Customer = _customerCatalog.DataPackage.Key;
            }
  
            //delete when implemented through catalog
            _catalog.DataPackage.FK_Status = 1;
            //

            _catalog.DataPackage.Date = DateTime.Now;
            
            if (_catalog.DataPackage.FK_City == null)
            {
                _catalog.DataPackage.FK_City = -1;
            }

            base.Execute();
        }
    }
}
