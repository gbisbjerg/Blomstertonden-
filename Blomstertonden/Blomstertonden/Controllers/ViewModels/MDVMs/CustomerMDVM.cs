using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerMDVM : MasterDetailsViewModelBase<CustomerTData, Customer, int>
    {
        public CustomerMDVM(ViewModelFactoryBase<CustomerTData, Customer, int> factoryVM) : base(factoryVM, CustomerCatalog.Instance)
        {
        }

        public override void SelectedItemEvent()
        {
            throw new NotImplementedException();
        }
        //All properties for binding to the given view
    }
}
