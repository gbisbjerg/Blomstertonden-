﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductUpdateCmd : UpdateCommandBase<ProductTData, Product, int>
    {
        //ProductCatalog _ProductCatalog;
        public ProductUpdateCmd(ICRUD<Product, ProductTData, int> catalog, MasterDetailsViewModelBase<ProductTData, Product, int> viewModel) : base(catalog, viewModel)
        {
            //_orderCatalog = OrderCatalog.Instance;
        }

        public override async void Execute()
        {
            await _catalog.Update(_catalog.DataPackage);

            //foreach (Order o in _catalog.All[_catalog.DataPackage.Key].Orders )
            //{

            //}

            ExecuteEvent();
        }
    }
}