using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blomstertonden;
using GenericsLibrary;

namespace Blomstertonden
{
    public class ViewOrderMDVM : MasterDetailsViewModelBase<OrderTData, Order, int>
    {
        private CustomerCatalog _customerCatalog;
        private OrderedProductCatalog _orderedProduct;
        private ViewModelFactoryBase<OrderedProductTData, OrderedProduct, int> _OrderedProductfactoryVM;

        public ViewOrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _OrderedProductfactoryVM = new OrderedProductVMFactory();
            _orderedProduct = OrderedProductCatalog.Instance;
            _customerCatalog = CustomerCatalog.Instance;
            _deleteCommand = new OrderDeleteCmd(_catalog, this);
            _updateCommand = new OrderUpdateCmd(_catalog, this);
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
            OnPropertyChanged(nameof(OrderStatus));
            OnPropertyChanged(nameof(PaymentType));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(DeliveryDate));
            OnPropertyChanged(nameof(OrderStatus));
            OnPropertyChanged(nameof(OrderProducts));

            _catalog.DataPackage.FK_Customer = Customer.Key;
            _catalog.DataPackage.FK_City = ItemViewModelSelected.Obj.FK_City;

            _catalog.DataPackage.FK_PaymentType = 1;
            _catalog.DataPackage.Street = "hi";
            _catalog.DataPackage.DeliveryDate = DateTime.Now;

            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();
        }

        public Dictionary<int, Status> StatusList { get => StatusCatalog.Instance.All; }

        public Customer Customer
        {
            get
            {
                if (ItemViewModelSelected.Obj.FK_Customer != 0)
                {
                    return CustomerFetch(ItemViewModelSelected.Obj.FK_Customer);
                }
                return new Customer();
            }
        }

        public Customer CustomerFetch(int FK_Customer)
        {
            foreach (Customer c in _customerCatalog.Data.Values)
            {
                if (c.Key == FK_Customer)
                {
                    return c;
                }
            }
            return new Customer();
        }

        //All properties for binding to the given view

        #region Customer Bindings
        public int CustomerId
        {
            get => _customerCatalog.DataPackage.Key = Customer.Key;
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
        #endregion
        #region Order Bindings
        public int Id => _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Key;

        public string Description
        {
            get => _catalog.DataPackage.Description = ItemViewModelSelected.Obj.Description;
            set => _catalog.DataPackage.Description = value;
        }
        public DateTime Date
        {
            get => _catalog.DataPackage.Date = ItemViewModelSelected.Obj.Date;
            set => _catalog.DataPackage.Date = value;
        }
        public string Street
        {
            get => _catalog.DataPackage.Street = ItemViewModelSelected.Obj.Street;
            set => _catalog.DataPackage.Street = value;
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
        public DateTimeOffset? DeliveryDate
        {
            get => _catalog.DataPackage.DeliveryDate = ItemViewModelSelected.Obj.DeliveryDate;
            set => _catalog.DataPackage.DeliveryDate = value;
        }

        #endregion
        #region ComboBox
        public List<PaymentType> PaymentTypeList
        {
            get { return OrderCatalog.Instance.PaymentTypeCatalog.PaymentTypeList; }
        }
        public int? PaymentType
        {
            get
            {
                _catalog.DataPackage.FK_PaymentType = ItemViewModelSelected.Obj.FK_PaymentType;
                return ItemViewModelSelected.Obj.FK_PaymentType - 1;
            }
            set { _catalog.DataPackage.FK_PaymentType = value + 1; }
        }

        public List<Status> OrderStatusList
        {
            get { return OrderCatalog.Instance.StatusCatalog.StatusList; }
        }
        public int OrderStatus
        {
            get
            {
                _catalog.DataPackage.FK_Status = ItemViewModelSelected.Obj.FK_Status;
                return  ItemViewModelSelected.Obj.FK_Status - 1;
            }
            set { _catalog.DataPackage.FK_Status = value + 1; }
        }
        #endregion

        #region ListofProducts
        public List<ItemViewModelBase<OrderedProduct, int>> OrderProducts
        {
            get => _OrderedProductfactoryVM.GetItemViewModelCollection(OrderedProductCatalog.Instance, ItemViewModelSelected.Obj.Key);
        }
        #endregion
    }
}
