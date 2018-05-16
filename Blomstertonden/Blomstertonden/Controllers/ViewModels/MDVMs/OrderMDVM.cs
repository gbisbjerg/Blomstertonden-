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
        private bool _isDelivering;
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
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(TotalPrice));

            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();

        }
        public Dictionary<int,Status> StatusList { get => StatusCatalog.Instance.All; } 

        public Customer Customer
        {
            get
            {
                if (ItemViewModelSelected.Obj.Customer != null)
                {
                    return ItemViewModelSelected.Obj.Customer;
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
            get => _catalog.DataPackage.Key =  ItemViewModelSelected.Obj.Id;
        }
        public string Name
        {
            get => _customerCatalog.DataPackage.Name = Customer.Name;
            set => CustomerCatalog.Instance.DataPackage.Name = value;
        }
        public int Phone
        {
            get => _customerCatalog.DataPackage.Phone = Customer.Phone;
            set => CustomerCatalog.Instance.DataPackage.Phone = value;
        }
        public string Description
        {
            get => _catalog.DataPackage.Description =  ItemViewModelSelected.Obj.Description;
            set => OrderCatalog.Instance.DataPackage.Description = value;
        }
        public int TotalPrice
        {
            get => _catalog.DataPackage.TotalPrice = ItemViewModelSelected.Obj.TotalPrice;
            set => OrderCatalog.Instance.DataPackage.TotalPrice = value;
        }
        public string CardMessage
        {
            get => _catalog.DataPackage.CardMessage = ItemViewModelSelected.Obj.CardMessage;
            set => OrderCatalog.Instance.DataPackage.CardMessage = value;
        }

        public bool IsDelivering
        {
            get { return _isDelivering; }
            set {
                    _isDelivering = value;
                    OnPropertyChanged();
                }
        }

        //public void SearchCustomer()
        //{
        //    Name = "Testing123";
        //    OnPropertyChanged(nameof(Name));
        //}

    }
}
