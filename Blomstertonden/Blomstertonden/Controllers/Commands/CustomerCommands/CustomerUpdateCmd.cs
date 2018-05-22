using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerUpdateCmd : UpdateCommandBase<CustomerTData, Customer, int>
    {
        //OrderCatalog _orderCatalog;
        public CustomerUpdateCmd(ICRUD<Customer, CustomerTData, int> catalog, MasterDetailsViewModelBase<CustomerTData, Customer, int> viewModel) : base(catalog, viewModel)
        {
            //_orderCatalog = OrderCatalog.Instance;
        }

        public async override void Execute()
        {
            await _catalog.Update(_catalog.DataPackage);
            await _catalog.LocalCreate(_catalog.DataPackage.Key);

            //foreach (Order o in _catalog.All[_catalog.DataPackage.Key].Orders )
            //{

            //}

            ExecuteEvent();
        }
    }
}
