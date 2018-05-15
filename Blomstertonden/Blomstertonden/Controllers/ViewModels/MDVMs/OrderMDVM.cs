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
            set => OrderCatalog.Instance.DataPackage.Key = value;
        }
        public string Name
        {
            get => ItemViewModelSelected.Obj.Customer.Name;
            set => CustomerCatalog.Instance.DataPackage.Name = value;
        }
        public int Phone
        {
            get => ItemViewModelSelected.Obj.Customer.Phone;
            set => CustomerCatalog.Instance.DataPackage.Phone = value;
        }
        public string Descrition
        {
            get => ItemViewModelSelected.Obj.Description;
            set => OrderCatalog.Instance.DataPackage.Description = value;
        }
        public int TotalPrice
        {
            get => ItemViewModelSelected.Obj.TotalPrice;
            set => OrderCatalog.Instance.DataPackage.TotalPrice = value;
        }

    }
}
