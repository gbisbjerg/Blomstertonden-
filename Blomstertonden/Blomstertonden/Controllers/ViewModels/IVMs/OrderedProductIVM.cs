using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class OrderedProductIVM : ItemViewModelBase<OrderedProduct, int>
    {
        public OrderedProductIVM(OrderedProduct obj) : base(obj)
        {

        }

        //properties for list view...
        public string Name
        {
            get => ProductCatalog.Instance.GetProduct( Obj.FK_Product ).Name;
        }

        public int Quantity
        {
            get => Obj.Quantity;
        }

        public int TotalPrice
        {
            get => Quantity * ProductCatalog.Instance.GetProduct(Obj.FK_Product).Price;
        }

    }
}
