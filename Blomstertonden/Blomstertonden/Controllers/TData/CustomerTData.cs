using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerTData : IKey<int>
    {
        public int Key { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int Stamps { get; set; }
    }
}
