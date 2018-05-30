using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ProductCatalog : AppCatalogBase<Product, ProductTData, int>
    {
        private static ProductCatalog _instance;
        private CategoryCatalog _categoryCatalog;

        private ProductCatalog(ProductFactory factory, string apiId) : base(factory, apiId)
        {
            _categoryCatalog = CategoryCatalog.Instance;
            Load();
        }

        public static ProductCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductCatalog(new ProductFactory(), "Products");
                }
                return _instance;
            }
        }

        public CategoryCatalog CategoryCatalog
        { get => _categoryCatalog; set => _categoryCatalog = value; }

        public List<Product> getProducts(string _catagory)
        {
            List<Product> products = new List<Product>();
            foreach (Product p in Data.Values)
            {
                Category category = _categoryCatalog.getCategory(p.FK_Category);

                if ( category.Name == _catagory)
                {
                    products.Add(p);
                }
            }
            return products;
        }

        public Category GetCategory(int key)
        {
            Category value = new Category();
            if (_categoryCatalog.All.TryGetValue(key, out value))
            {
                return value;
            }
            return new Category();
        }

        public Product GetProduct(int key)
        {
            Product value = new Product();
            if (_data.TryGetValue(key, out value))
            {
                return value;
            }
            return new Product();
        }
    }
}
