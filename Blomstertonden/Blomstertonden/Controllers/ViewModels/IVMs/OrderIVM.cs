using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderIVM : ItemViewModelBase<Order, int>
    {
        public OrderIVM(Order obj) : base(obj)
        {
        }
        //properties for list view...
        public int ID
        {
            get => Obj.Id;
        }
        public DateTime Date
        {
            get => Obj.Date;
        }
        public int Price
        {
            get => Obj.TotalPrice;
        }


    }
}
