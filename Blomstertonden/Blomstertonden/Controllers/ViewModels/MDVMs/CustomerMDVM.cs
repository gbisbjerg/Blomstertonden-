using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerMDVM : MasterDetailsViewModelBase<CustomerTData, Customer, int>
    {
        public CustomerMDVM() : base(new CustomerVMFactory(), CustomerCatalog.Instance)
        {
            _createCommand = new CustomerCreateCmd(_catalog, this);
            _deleteCommand = new CustomerDeleteCmd(_catalog, this);
            _updateCommand = new CustomerUpdateCmd(_catalog, this);
        }

        public override void SelectedItemEvent()
        {
            throw new NotImplementedException();
        }
        //All properties for binding to the given view
        public string Name
        {
            get => ItemViewModelSelected.Obj.Name;
            set => DataPackage.Name = value;
        }

        public int Phone
        {
            get => ItemViewModelSelected.Obj.Phone;
            set => DataPackage.Phone = value;
        }

        public int Stamps
        {
            get => ItemViewModelSelected.Obj.Stamps;
            set => DataPackage.Stamps = value;
        }
    }
}
