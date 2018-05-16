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
        public Dictionary<int, Status> StatusList { get => StatusCatalog.Instance.All; }

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
            get => _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Id;
        }

        public int CustomerId
        {
            get => _customerCatalog.DataPackage.Key;
            set => _customerCatalog.DataPackage.Key = value;
        }
        public string Name
        {
            get => _customerCatalog.DataPackage.Name = Customer.Name;
            set => _customerCatalog.DataPackage.Name = value;
        }
        public int Phone
        {
            get => _customerCatalog.DataPackage.Phone = Customer.Phone;
            set => _customerCatalog.DataPackage.Phone = value;
        }

        public int Stamps
        {
            get => _customerCatalog.DataPackage.Stamps = Customer.Stamps;
            set => _customerCatalog.DataPackage.Stamps = value;
        }
        public string Description
        {
            get => _catalog.DataPackage.Description = ItemViewModelSelected.Obj.Description;
            set => _catalog.DataPackage.Description = value;
        }
        public int TotalPrice
        {
            get => _catalog.DataPackage.TotalPrice = ItemViewModelSelected.Obj.TotalPrice;
            set => _catalog.DataPackage.TotalPrice = value;
        }
        public string CardMessage
        {
            get => _catalog.DataPackage.CardMessage = ItemViewModelSelected.Obj.CardMessage;
            set => _catalog.DataPackage.CardMessage = value;
        }

        public bool IsDelivering
        {
            get => _isDelivering;
            set
            {
                _isDelivering = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<int, PaymentType> PaymentTypeList
        {
            get { return OrderCatalog.Instance.PaymentTypeCatalog.All; }
        }
        public int? FK_PaymentType
        {
            get { return _catalog.DataPackage.FK_PaymentType; }
            set { _catalog.DataPackage.FK_PaymentType = value; }
        }



    }
}
