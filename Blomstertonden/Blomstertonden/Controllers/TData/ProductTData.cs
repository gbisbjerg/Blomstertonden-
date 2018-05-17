using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductTData : IKey<int>
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsPromational { get; set; }
        public int FK_Category { get; set; }
    }
}
