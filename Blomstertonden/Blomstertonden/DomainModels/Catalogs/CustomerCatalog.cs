using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerCatalog : AppCatalogBase<Customer, CustomerTData, int>
    {
        private static CustomerCatalog _instance;
        
        private CustomerCatalog(CustomerFactory factory, string apiId) : base(factory, apiId)
        {
            Load();
        }
        public static CustomerCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerCatalog(new CustomerFactory(), "Customers");
                }
                return _instance;
            }
        }

        //This method adds a stamp to the provided customer
        public async void AddStamp(CustomerTData customerDataPackage)
        {
            customerDataPackage.Stamps += 1;
            await Update(customerDataPackage);
            
        }



    }
}
