using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderedProductTData : IKey<Tuple<int, int>>
    {
        public Tuple<int, int> Key { get =>  new Tuple<int, int>(FK_Order,FK_Product); set => Key = value; }

        public int FK_Order { get; set; }

        public int FK_Product { get; set; }

        public int Quantity { get; set; }
    }
}
