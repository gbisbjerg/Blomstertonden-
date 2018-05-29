using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerMDVM : MasterDetailsViewModelBase<CustomerTData, Customer, int>
    {
        CustomerOrdersVMFactory _customerOrdersVMFactory;
        public CustomerMDVM() : base(new CustomerVMFactory(), CustomerCatalog.Instance)
        {
            _customerOrdersVMFactory = new CustomerOrdersVMFactory();
            _deleteCommand = new CustomerDeleteCmd(_catalog, this);
            _updateCommand = new CustomerUpdateCmd(_catalog, this);
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Stamps));
            _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Key;

            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();

            //orderCatalog.getCustomerOrders(FK_Customer);
            OnPropertyChanged(nameof(CustomerOrders));
        }
        //All properties for binding to the given view
        public string Name
        {
            get => _catalog.DataPackage.Name = ItemViewModelSelected.Obj.Name;
            set => _catalog.DataPackage.Name = value;
        }

        public int Phone
        {
            get => _catalog.DataPackage.Phone = ItemViewModelSelected.Obj.Phone;
            set => _catalog.DataPackage.Phone = value;
        }

        public int Stamps
        {
            get => _catalog.DataPackage.Stamps = ItemViewModelSelected.Obj.Stamps;
            set => _catalog.DataPackage.Stamps = value;
        }

        public List<ItemViewModelBase<Order, int>> CustomerOrders
        {
            get => _customerOrdersVMFactory.GetItemViewModelCollection(OrderCatalog.Instance, ItemViewModelSelected.Obj.Key);
        }


    }
}
