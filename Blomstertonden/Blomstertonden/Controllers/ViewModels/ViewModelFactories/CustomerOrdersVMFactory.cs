using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class CustomerOrdersVMFactory : ViewModelFactoryBase<OrderTData, Order, int>
    {
        public override ItemViewModelBase<Order, int> CreateItemViewModel(Order obj)
        {
            return new OrderIVM(obj);
        }

        public override List<ItemViewModelBase<Order, int>> GetItemViewModelCollection(ICRUD<Order, OrderTData, int> catalog, int fk_customer)
        {
            List<ItemViewModelBase<Order, int>> items = new List<ItemViewModelBase<Order, int>>();

            foreach (Order obj in catalog.All.OrderByDescending(Model => Model.Key))
            {
                if (fk_customer == obj.FK_Customer)
                {
                    items.Add(CreateItemViewModel(obj));
                }
                
            }
            return items;
        }

    }
}
