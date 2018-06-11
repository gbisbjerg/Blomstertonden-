using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderedProductTData : IKey<int>
    {
        public OrderedProductTData()
        {
        }
        public int Key { get; set; }

        public int FK_Order { get; set; }

        public int FK_Product { get; set; }

        public int Quantity { get; set; }

        //Not used except for listview binding
        public string Name { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get { return Price * Quantity; } }
    }
}
