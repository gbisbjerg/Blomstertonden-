using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerIVM : ItemViewModelBase<Customer, int>
    {
        public CustomerIVM(Customer obj) : base(obj)
        {
        }
        //properties for list view...
        public string Name
        {
            get => Obj.Name;
        }
        public int Stamp
        {
            get => Obj.Stamps;
        }
    }
}
