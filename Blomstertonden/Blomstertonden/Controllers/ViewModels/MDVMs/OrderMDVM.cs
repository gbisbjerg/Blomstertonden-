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
        public Customer GetCustomer
        {
            get
            {
                Customer outCustomer;
                int customer_key = ItemViewModelSelected.Obj.FK_Customer;
                if (_customerCatalog.Data.TryGetValue(customer_key, out outCustomer))
                {
                    return outCustomer;
                }
                else
                {
                    return new Customer();
                }
            }
        }

        //All properties for binding to the given view
        public int Id
        {
            get => ItemViewModelSelected.Obj.Id;
            set => OrderCatalog.Instance.DataPackage.Key = value;
        }
        public string Name
        {
            get => GetCustomer.Name;
            set => CustomerCatalog.Instance.DataPackage.Name = value;
        }
        public int Phone
        {
            get => GetCustomer.Phone;
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
