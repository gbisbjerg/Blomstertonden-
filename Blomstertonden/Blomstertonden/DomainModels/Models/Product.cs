using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public partial class Product : IKey<int>
    {
        public int Key { get; set; }

    }
}
