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
        private ProductCatalog _productCatalog = ProductCatalog.Instance;
        public ProductMDVM() : base(new ProductVMFactory(), ProductCatalog.Instance)
        {
            //commands see CustomerMDVM for an example
            _deleteCommand = new ProductDeleteCmd(_catalog, this);
            _updateCommand = new ProductUpdateCmd(_catalog, this);
            _createCommand = new ProductCreateCmd(_catalog, this);

        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(IsPromotional));
            OnPropertyChanged(nameof(CategoryName));
            _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Key;

            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();
            _createCommand.RaiseCanExecuteChanged();
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

        public int FK_Category
        {
            get => _catalog.DataPackage.FK_Category = ItemViewModelSelected.Obj.FK_Category;
            set => _catalog.DataPackage.FK_Category = value;
        }

        public string CategoryName
        {
            get => ProductCatalog.Instance.GetCategory(FK_Category).Name;
        }

        public List<Category> ProductCategoryList
        {
            get { return CategoryCatalog.Instance.CategoryList; }
        }

        public int ProductCategory
        {
            get { return ProductCatalog.Instance.DataPackage.FK_Category -1; }
            set { ProductCatalog.Instance.DataPackage.FK_Category = value +1; }
        }
    }
}
