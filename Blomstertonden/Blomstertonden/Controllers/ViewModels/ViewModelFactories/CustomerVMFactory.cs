using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerVMFactory : ViewModelFactoryBase<CustomerTData, Customer, int>
    {
        public override ItemViewModelBase<Customer, int> CreateItemViewModel(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
