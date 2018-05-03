using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerCreateCmd : CreateCommandBase<CustomerTData, Customer, int>
    {
        public CustomerCreateCmd(ICRUD<Customer, CustomerTData, int> catalog, MasterDetailsViewModelBase<CustomerTData, Customer, int> viewModel) : base(catalog, viewModel)
        {
        }
    }
}
