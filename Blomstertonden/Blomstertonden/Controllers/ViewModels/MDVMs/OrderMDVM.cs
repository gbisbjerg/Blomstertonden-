using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderMDVM : MasterDetailsViewModelBase<OrderTData, Order, int>
    {
        private CustomerCatalog _customerCatalog;
        private ProductCatalog _productCatalog;
        private OrderedProductCatalog _orderedProductCatalog;
        private bool _isDelivering;
        private CustomerSearchCmd _customerSerarchCmd;
        private Product _productItemViewModelSelected;
        private AddProductToOrder _addProductCmd;
        private DeleteProductFromOrderCmd _deleteProductFromOrderCmd;
        private ClearDataPackagesCmd _clear;
        private bool _isProductSelected = false;

        private static ObservableCollection<OrderedProductTData> _addedProducts = new ObservableCollection<OrderedProductTData>();
        private OrderedProductTData _selectedProduct;

        public OrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _customerCatalog = CustomerCatalog.Instance;
            _productCatalog = ProductCatalog.Instance;
            _orderedProductCatalog = OrderedProductCatalog.Instance;

            _clear = new ClearDataPackagesCmd();
            _addProductCmd = new AddProductToOrder(this);
            _deleteProductFromOrderCmd = new DeleteProductFromOrderCmd(this);
            _createCommand = new OrderCreateCmd(_catalog, this);
            _customerSerarchCmd = new CustomerSearchCmd(this);
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Quantity));

            _orderedProductCatalog.DataPackage.Name = LastProduct.Name;
            _orderedProductCatalog.DataPackage.Price = LastProduct.Price;
            _orderedProductCatalog.DataPackage.FK_Product = LastProduct.Key;

            _addProductCmd.RaiseCanExecuteChanged();
        }


        #region OrderedProduct
        public void RefreshProductItemViewModelCollection()
        {
            OnPropertyChanged(nameof(AddedProducts));
            OnPropertyChanged(nameof(TotalPrice));
        }

        public AddProductToOrder AddProductCommand
        {
            get { return _addProductCmd; }
        }

        public Product LastProduct
        {
            get;
            set;
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
                LastProduct = value;
                _productItemViewModelSelected = null;
                OnPropertyChanged();
                _productItemViewModelSelected = value;
                SelectedItemEvent();
            }
        }

        public List<Product> ProductBuketList { get => _productCatalog.getProducts("Buket"); }
        public List<Product> ProductBrugskunstList { get => _productCatalog.getProducts("Brugskunst"); }
        public List<Product> ProductSpecialiteterList { get => _productCatalog.getProducts("Specialiteter"); }
        //public List<Product> ProductSaesonList { get => _productCatalog.getProducts("Sæson"); }
        //public List<Product> ProductAloeVeraList { get => _productCatalog.getProducts("AloeVera"); }
        //public List<Product> ProductEuroFloristList { get => _productCatalog.getProducts("EuroFlorist"); }
        //public List<Product> ProductDiverseList { get => _productCatalog.getProducts("Diverse"); }
        //public List<Product> ProductLeveringList { get => _productCatalog.getProducts("Levering"); }
        //public List<Product> ProductBegravelseList { get => _productCatalog.getProducts("Begravelse"); }
        //public List<Product> ProductPotteplanteList { get => _productCatalog.getProducts("Potteplante"); }
        //public List<Product> ProductBidList { get => _productCatalog.getProducts("Bod"); }

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
        public Dictionary<int, Status> StatusList { get => StatusCatalog.Instance.All; }

        public ObservableCollection<OrderedProductTData> AddedProducts
        {
            get => _addedProducts = new ObservableCollection<OrderedProductTData>( _orderedProductCatalog.OPTDataList);
            set => _addedProducts = value; 
        }
        
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
            //get => _catalog.DataPackage.TotalPrice;
            get => _catalog.DataPackage.TotalPrice = CalcTotalPrice();
            set => _catalog.DataPackage.TotalPrice = value;
        }

        public int CalcTotalPrice()
        {
            int total = 0;
            foreach (OrderedProductTData opTData in _orderedProductCatalog.OPTDataList)
            {
                Product product;
                _productCatalog.Data.TryGetValue(opTData.FK_Product, out product);
                total += product.Price * opTData.Quantity;
            }
            return total;
        }


        public string CardMessage
        {
            get => _catalog.DataPackage.CardMessage;
            set
            { _catalog.DataPackage.CardMessage = value;
              OnPropertyChanged();
            }
        }

        public DateTimeOffset? DeliveryDate
        {
            get =>  _catalog.DataPackage.DeliveryDate = DateTime.Now;
            set => _catalog.DataPackage.DeliveryDate = value.Value.DateTime;
        }

        #endregion

        #region OrderedProduct
        public int Quantity
        {
            get => _orderedProductCatalog.DataPackage.Quantity;
            set => _orderedProductCatalog.DataPackage.Quantity = value;
        }
        public OrderedProductTData SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                IsProductItemSelected = true;
                _deleteProductFromOrderCmd.RaiseCanExecuteChanged();
            }
        }
        public ICommand DeleteProductFromOrder => _deleteProductFromOrderCmd;

        public bool IsProductItemSelected
        {
            get => _isProductSelected;
            set
            {
                _isProductSelected = value;
                OnPropertyChanged();
            }
        }
        #endregion



        public ICommand CustomerSerarchCmd
        {
            get
            {
                try
                {
                    return _customerSerarchCmd;
                }
                catch (Exception e)
                {
                    ErrorBoxText = e.ToString();
                    OnPropertyChanged(nameof(IsErrorBoxVisible));
                }
                return new CommandDoNothing();
            }
        }

        public bool IsErrorBoxVisible { get; }
        public string ErrorBoxText { get; set; }

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


        public ICommand Clear { get => _clear; }
    }
}
