using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderVMFactory : ViewModelFactoryBase<OrderTData, Order, int>
    {
        public override ItemViewModelBase<Order, int> CreateItemViewModel(Order obj)
        {
            return new OrderIVM(obj);
        }
    }
}
