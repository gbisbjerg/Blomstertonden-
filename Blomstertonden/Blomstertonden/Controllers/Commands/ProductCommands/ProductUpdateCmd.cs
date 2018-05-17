using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductUpdateCmd : UpdateCommandBase<ProductTData, Product, int>
    {
        public ProductUpdateCmd(ICRUD<Product, ProductTData, int> catalog, MasterDetailsViewModelBase<ProductTData, Product, int> viewModel) : base(catalog, viewModel)
        {
        }
    }
}