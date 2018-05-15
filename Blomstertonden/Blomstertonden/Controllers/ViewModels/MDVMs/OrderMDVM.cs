using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderMDVM : MasterDetailsViewModelBase<OrderTData, Order, int>
    {
        private Customer _customer;
        private CustomerCatalog _customerCatalog;
        public OrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _customerCatalog = CustomerCatalog.Instance;
            _deleteCommand = new OrderDeleteCmd(_catalog, this);
            _updateCommand = new OrderUpdateCmd(_catalog, this);
            _createCommand = new OrderCreateCmd(_catalog, this);
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Descrition));
            OnPropertyChanged(nameof(TotalPrice));

        }

        //All properties for binding to the given view
        public int Id
        {
            get => ItemViewModelSelected.Obj.Id;
        }
        public string Name
        {
            get => ItemViewModelSelected.Obj.Customer.Name;
            set => _customerCatalog.DataPackage.Name = value;
        }
        public int Phone
        {
            get => ItemViewModelSelected.Obj.Customer.Phone;
            set => _customerCatalog.DataPackage.Phone = value;
        }
        public string Descrition
        {
            get => ItemViewModelSelected.Obj.Description;
            set => _catalog.DataPackage.Description = value;
        }
        public int TotalPrice
        {
            get => ItemViewModelSelected.Obj.TotalPrice;
            set => _catalog.DataPackage.TotalPrice = value;
        }

    }
}
