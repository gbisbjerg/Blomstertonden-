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
        private ProductCatalog _productCatalog;
        private ProductVMFactory _productVMFactory;
        private bool _isDelivering;
        private CustomerSearchCmd _customerSerarchCmd;
        private Product _productItemViewModelSelected;
        private AddProductToOrder _addProductCmd;

        public OrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _customerCatalog = CustomerCatalog.Instance;
            _productCatalog = ProductCatalog.Instance;
            _productVMFactory = new ProductVMFactory();

            _addProductCmd = new AddProductToOrder(this);
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
            //Dont know if we need to stuff above

            _addProductCmd.RaiseCanExecuteChanged();
            //OnPropertyChanged(nameof(ProductItemViewModelSelected));

            OnPropertyChanged(nameof(Order_Products));
        }
        public Dictionary<int, Status> StatusList { get => StatusCatalog.Instance.All; }

        #region Product List
        public void RefreshProductItemViewModelCollection()
        {
            OnPropertyChanged(nameof(Order_Products));
        }

        public AddProductToOrder AddProductCommand
        {
            get { return _addProductCmd; }
        }
        public Product _lastProduct;
        public Product LastProduct
        {
            get { return _lastProduct; }
        }

        public Product ProductItemViewModelSelected
        {
            get
            {
                return _productItemViewModelSelected;
            }
            set
            {
                IsItemSelected = true;
                _lastProduct = value;
                _productItemViewModelSelected = null;
                OnPropertyChanged();

                _productItemViewModelSelected = value;
                SelectedItemEvent();
            }
        }

        public List<Product> ProductFlowerList { get => _productCatalog.getProducts("Flowers"); }
        public List<Product> ProductWineList { get => _productCatalog.getProducts("Wine"); }
        public List<Product> ProductChocolateList { get => _productCatalog.getProducts("Chocolate"); }
        #endregion

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
        public List<Product> Order_Products { get => _catalog.DataPackage.Order_Products; }
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
            get { return OrderCatalog.Instance.DataPackage.FK_Status - 1 ; }
            set { OrderCatalog.Instance.DataPackage.FK_Status = value + 1; }
        }
       
        #endregion
    }
}
