using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderedProductVMFactory : ViewModelFactoryBase<OrderedProductTData, OrderedProduct, int>
    {
        public override ItemViewModelBase<OrderedProduct, int> CreateItemViewModel(OrderedProduct obj)
        {
            return new OrderedProductIVM(obj);
        }

        public override List<ItemViewModelBase<OrderedProduct, int>> GetItemViewModelCollection(ICRUD<OrderedProduct, OrderedProductTData, int> catalog, int fk_order)
        {
            List<ItemViewModelBase<OrderedProduct, int>> items = new List<ItemViewModelBase<OrderedProduct, int>>();

            foreach (OrderedProduct obj in catalog.All.OrderByDescending(Model => Model.Key))
            {
                if (fk_order == obj.FK_Order)
                {
                    items.Add(CreateItemViewModel(obj));
                }

            }
            return items;
        }
    }
}
