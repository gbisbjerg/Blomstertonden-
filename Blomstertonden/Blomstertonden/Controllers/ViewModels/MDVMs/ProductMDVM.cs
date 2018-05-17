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
        private CategoryCatalog _categoryCatalog;
        public ProductMDVM(ViewModelFactoryBase<ProductTData, Product, int> factoryVM) : base(factoryVM, ProductCatalog.Instance)
        {
            //commands see CustomerMDVM for an example
            _deleteCommand = new ProductDeleteCmd(_catalog, this);
            _updateCommand = new ProductUpdateCmd(_catalog, this);
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(IsPromotional));
            _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Key;

            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();
        }
        //All properties for binding to the given view
        public string Name
        {
            get => _catalog.DataPackage.Name = ItemViewModelSelected.Obj.Name;
            set => _catalog.DataPackage.Name = value;
        }

        public int Price
        {
            get => _catalog.DataPackage.Price = ItemViewModelSelected.Obj.Price;
            set => _catalog.DataPackage.Price = value;
        }

        public bool IsPromotional
        {
            get => _catalog.DataPackage.IsPromational = ItemViewModelSelected.Obj.IsPromational;
            set => _catalog.DataPackage.IsPromational = value;
        }
    }
}
