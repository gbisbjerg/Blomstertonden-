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
        private Category FK_Obj;
        public ProductIVM(Product obj) : base(obj)
        {
            FK_Obj = ProductCatalog.Instance.GetCategory(Obj.FK_Category);
        }
        //properties for list view...
        public string Name
        {
            get => Obj.Name;
        }
        public int Price
        {
            get => Obj.Price;
        }

        public string CategoryName
        {
            get => FK_Obj.Name;
        }
        //public Boolean IsPromotional
        //{
        //    get => Obj.IsPromational;
        //}     
    }
}
