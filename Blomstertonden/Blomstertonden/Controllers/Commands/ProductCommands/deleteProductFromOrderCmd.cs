using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using GenericsLibrary;

namespace Blomstertonden
{
    class DeleteProductFromOrderCmd : ICommand
    {
        OrderedProductCatalog _orderedProductCatalog;
        private OrderMDVM _orderMDVM;
        public DeleteProductFromOrderCmd(OrderMDVM orderMDVM)
        {
            _orderedProductCatalog = OrderedProductCatalog.Instance;
            _orderMDVM = orderMDVM;
        }

        public bool CanExecute(object parameter)
        {
            return _orderMDVM.IsProductItemSelected;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            OrderedProductTData OPTData =  _orderMDVM.SelectedProduct;
            _orderedProductCatalog.OPTDataList.Remove(OPTData);
            _orderMDVM.IsItemSelected = false;
            _orderMDVM.RefreshProductItemViewModelCollection();
        }


    }
}
