using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class ProductCreateCmd : CreateCommandBase<ProductTData, Product, int>
    {
        private ProductCatalog _productCatalog;
        public ProductCreateCmd(ICRUD<Product, ProductTData, int> catalog, MasterDetailsViewModelBase<ProductTData, Product, int> viewModel) : base(ProductCatalog.Instance, viewModel)
        {
            _productCatalog = ProductCatalog.Instance;
        }

        //public override async void Execute()
        //{
        //    if (_productCatalog.DataPackage.Key != 0)
        //    {
        //        _catalog.DataPackage.FK_Category = await _productCatalog.Create(_productCatalog.DataPackage);
        //    }
        //    else
        //    {
        //        _catalog.DataPackage.FK_Category = _productCatalog.DataPackage.Key;
        //    }

        //    base.Execute();
        //}
    }
}
