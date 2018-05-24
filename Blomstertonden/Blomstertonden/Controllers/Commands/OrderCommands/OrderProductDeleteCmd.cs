using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderProductDeleteCmd : ICommand
    {
        private OrderMDVM _orderMDVM;
        public OrderProductDeleteCmd(OrderMDVM orderMDVM)
        {
            _orderMDVM = orderMDVM;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Make Itemselected equals something when you click and then we can remove that specific item
            _orderMDVM.AddedProducts.RemoveAt(-1);
        }

        public event EventHandler CanExecuteChanged;
    }
}
