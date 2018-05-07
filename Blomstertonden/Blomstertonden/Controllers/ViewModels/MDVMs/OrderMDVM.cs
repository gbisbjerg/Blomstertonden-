using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderMDVM : MasterDetailsViewModelBase<OrderTData, Order, int>
    {
        private CustomerMDVM _customerVM;
        public OrderMDVM(ViewModelFactoryBase<OrderTData, Order, int> factoryVM) : base(factoryVM, OrderCatalog.Instance)
        {
            _customerVM = new CustomerMDVM();
        }
        public CustomerMDVM CustomerVM{ get => _customerVM; }
        public override void SelectedItemEvent()
        {
            throw new NotImplementedException();
        }
        //All properties for binding to the given view

    }
}
