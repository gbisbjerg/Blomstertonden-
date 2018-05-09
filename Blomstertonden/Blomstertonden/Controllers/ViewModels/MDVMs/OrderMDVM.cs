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
        public OrderMDVM() : base(new OrderVMFactory(), OrderCatalog.Instance)
        {
            _customerCatalog = CustomerCatalog.Instance;
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Id));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Descrition));
            OnPropertyChanged(nameof(CardMessage));
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
            get => Customer.Name;
            set => _customerCatalog.DataPackage.Name = value;
        }
        public int Phone
        {
            get => Customer.Phone;
            set => _customerCatalog.DataPackage.Phone = value;
        }
        public int Stamps
        {
            get => Customer.Stamps;
        }
        public string Descrition
        {
            get => ItemViewModelSelected.Obj.Description;
            set => OrderCatalog.Instance.DataPackage.Description = value;
        }
        public string CardMessage
        {
            get => ItemViewModelSelected.Obj.CardMessage;
            set => OrderCatalog.Instance.DataPackage.CardMessage = value;
        }
        public int TotalPrice
        {
            get => ItemViewModelSelected.Obj.TotalPrice;
            set => OrderCatalog.Instance.DataPackage.TotalPrice = value;
        }

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
    }
}
