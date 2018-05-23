using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blomstertonden
{
    public class AddProductToOrder : ICommand, INotifyPropertyChanged
    {
        OrderedProductCatalog _orderedProductCatalog;
        private OrderMDVM _orderMDVM;
        public AddProductToOrder (OrderMDVM orderMDVM)
        {
            _orderedProductCatalog = OrderedProductCatalog.Instance;
            _orderMDVM = orderMDVM;
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return _orderMDVM.IsItemSelected;
        }

        public void Execute(object parameter)
        {
            //remove when quanitity is implimented
            if (_orderedProductCatalog.DataPackage.Quantity <= 0)
            {
                _orderedProductCatalog.DataPackage.Quantity = 1;
            }
            
            _orderMDVM.AddedProducts.Add(_orderMDVM.LastProduct);
            _orderedProductCatalog.OPTDataList.Add(_orderedProductCatalog.DataPackage);
            _orderedProductCatalog.DataPackage = new OrderedProductTData();

            _orderMDVM.ProductItemViewModelSelected = new Product();
            _orderMDVM.IsItemSelected = false;
            _orderMDVM.RefreshProductItemViewModelCollection();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
