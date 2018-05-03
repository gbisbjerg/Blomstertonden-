using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductMDVM : MasterDetailsViewModelBase<ProductTData, Product, int>
    {
        public ProductMDVM(ViewModelFactoryBase<ProductTData, Product, int> factoryVM) : base(factoryVM, ProductCatalog.Instance)
        {
        }

        public override void SelectedItemEvent()
        {
            throw new NotImplementedException();
        }
        //All properties for binding to the given view
    }
}
