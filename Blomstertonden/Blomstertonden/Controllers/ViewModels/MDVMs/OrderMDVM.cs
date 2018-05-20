using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderMDVM : MasterDetailsViewModelBase<OrderTData, Order, int>
    {
        //
        private CustomerCatalog _customerCatalog;
        private bool _isDelivering;
        private CustomerSearchCmd _customerSerarchCmd;

        public OrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _customerCatalog = CustomerCatalog.Instance;
            _createCommand = new OrderCreateCmd(_catalog, this);
            _customerSerarchCmd = new CustomerSearchCmd(this);
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(CustomerId));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Stamps));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(TotalPrice));
            OnPropertyChanged(nameof(Street));
            OnPropertyChanged(nameof(CardMessage));
        }
        public Dictionary<int, Status> StatusList { get => StatusCatalog.Instance.All; }

        //All properties for binding to the given view

        #region Customer Bindings
        public int CustomerId
        {
            get => _customerCatalog.DataPackage.Key;
            set
            {
                _customerCatalog.DataPackage.Key = value; 
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _customerCatalog.DataPackage.Name;
            set
            {
                _customerCatalog.DataPackage.Name = value;
                OnPropertyChanged();
            }
        }
        public int Phone
        {
            get => _customerCatalog.DataPackage.Phone;
            set
            {
                _customerCatalog.DataPackage.Phone = value;
                OnPropertyChanged();
            }
        }

        public int Stamps
        {
            get => _customerCatalog.DataPackage.Stamps;
            set
            {
                _customerCatalog.DataPackage.Stamps = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Order Bindings
        public int Id => _catalog.DataPackage.Key;

        public string Description
        {
            get => _catalog.DataPackage.Description;
            set => _catalog.DataPackage.Description = value;
        }
        public string Street
        {
            get => _catalog.DataPackage.Street;
            set => _catalog.DataPackage.Street = value;
        }
        public int TotalPrice
        {
            get => _catalog.DataPackage.TotalPrice;
            set => _catalog.DataPackage.TotalPrice = value;
        }
        public string CardMessage
        {
            get => _catalog.DataPackage.CardMessage;
            set => _catalog.DataPackage.CardMessage = value;
        }
        #endregion

        public CustomerSearchCmd CustomerSerarchCmd => _customerSerarchCmd;

        public bool IsDelivering
        {
            get => _isDelivering;
            set
            {
                _isDelivering = value;
                OnPropertyChanged();
            }
        }
        #region ComboBox
        public List<PaymentType> PaymentTypeList
        {
            get { return OrderCatalog.Instance.PaymentTypeCatalog.PaymentTypeList; }
        }
        public int? PaymentType
        {
            get { return OrderCatalog.Instance.DataPackage.FK_PaymentType - 1; }
            set { OrderCatalog.Instance.DataPackage.FK_PaymentType = value + 1; }
        }

        public List<Status> OrderStatusList
        {
            get { return OrderCatalog.Instance.StatusCatalog.StatusList; }
        }
        public int OrderStatus
        {
            get { return OrderCatalog.Instance.DataPackage.FK_Status - 1; }
            set { OrderCatalog.Instance.DataPackage.FK_Status = value + 1; }
        }
        #endregion
    }
}
