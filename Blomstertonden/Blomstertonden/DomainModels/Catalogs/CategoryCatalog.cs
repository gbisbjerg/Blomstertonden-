using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blomstertonden
{
    public class CategoryCatalog : ReadOnlyCatalogBase<Status, int>
    {
        private static CategoryCatalog _instance;
        private CategoryCatalog() : base(AppConfig.ServerURL, "Categories")
        {
        }

        public static CategoryCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryCatalog();
                }
                return _instance;
            }
        }
    }
}
