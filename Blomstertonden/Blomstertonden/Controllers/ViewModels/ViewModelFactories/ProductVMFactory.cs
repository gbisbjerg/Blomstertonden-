using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductVMFactory : ViewModelFactoryBase<ProductTData, Product, int>
    {
        public override ItemViewModelBase<Product, int> CreateItemViewModel(Product obj)
        {
            return new ProductIVM(obj);
        }

    }
}
