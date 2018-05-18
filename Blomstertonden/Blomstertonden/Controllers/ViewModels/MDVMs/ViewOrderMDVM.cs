﻿using System;
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

        public ViewOrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
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
                return new Customer();
            }
        }
        //All properties for binding to the given view

        #region Customer Bindings
        public int CustomerId
        {
            get => _customerCatalog.DataPackage.Key = Customer.Id;
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
        public int Id => _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Id;

        public string Description
        {
            get => _catalog.DataPackage.Description = ItemViewModelSelected.Obj.Description;
            set => _catalog.DataPackage.Description = value;
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
        #endregion
        #region ComboBox
        public List<PaymentType> PaymentTypeList
        {
            get { return OrderCatalog.Instance.PaymentTypeCatalog.PaymentTypeList; }
        }
        public int? PaymentType
        {
            get { return OrderCatalog.Instance.DataPackage.FK_PaymentType; }
            set { OrderCatalog.Instance.DataPackage.FK_PaymentType = value + 1; }
        }

        public List<Status> OrderStatusList
        {
            get { return OrderCatalog.Instance.StatusCatalog.StatusList; }
        }
        public int OrderStatus
        {
            get { return OrderCatalog.Instance.DataPackage.FK_Status; }
            set { OrderCatalog.Instance.DataPackage.FK_Status = value + 1; }
        }
        #endregion
    }
}