using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductIVM : ItemViewModelBase<Product, int>
    {
        public ProductIVM(Product obj) : base(obj)
        {
        }
        //properties for list view...
    }
}
