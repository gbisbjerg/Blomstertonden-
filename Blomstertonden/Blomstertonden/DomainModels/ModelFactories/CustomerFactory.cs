using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerFactory : IFactory<CustomerTData, Customer>
    {
        public Customer Convert(CustomerTData data)
        {
            throw new NotImplementedException();
        }
    }
}
