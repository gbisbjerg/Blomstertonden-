using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Blomstertonden
{
    public class AddProductToOrder : ICommand

    {
        private OrderMDVM _orderMDVM;
        public AddProductToOrder (OrderMDVM orderMDVM)
        {
            _orderMDVM = orderMDVM;
        }

        public event EventHandler CanExecuteChanged;
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
            _orderMDVM.Catalog.DataPackage.Order_Products.Add(_orderMDVM.LastProduct);
            _orderMDVM.ProductItemViewModelSelected = null;
            _orderMDVM.IsItemSelected = false;
            _orderMDVM.RefreshProductItemViewModelCollection();
        }
    }
}
