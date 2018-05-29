using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderDeleteCmd : DeleteCommandBase<OrderTData, Order, int>
    {
        public OrderDeleteCmd(ICRUD<Order, OrderTData, int> catalog, MasterDetailsViewModelBase<OrderTData, Order, int> viewModel) : base(catalog, viewModel)
        {
        }

        public override void Execute()
        {
            int ordernumber = _viewModel.ItemViewModelSelected.Obj.Key;

            OrderedProductCatalog.Instance.DeleteOrdersOP(ordernumber);

            base.Execute();
        }
    }
}
