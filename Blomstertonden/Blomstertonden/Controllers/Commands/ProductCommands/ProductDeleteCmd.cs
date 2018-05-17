using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductDeleteCmd : DeleteCommandBase<ProductTData, Product, int>
    {
        public ProductDeleteCmd(ICRUD<Product, ProductTData, int> catalog, MasterDetailsViewModelBase<ProductTData, Product, int> viewModel) : base(catalog, viewModel)
        {
        }
    }
}
