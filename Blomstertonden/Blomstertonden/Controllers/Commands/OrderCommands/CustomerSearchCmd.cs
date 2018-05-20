using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GenericsLibrary;

namespace Blomstertonden
{
    public class CustomerSearchCmd : CommandBase<OrderTData, Order, int>
    {
        private OrderMDVM _vm;
        public CustomerSearchCmd(OrderMDVM viewModel) : base(OrderCatalog.Instance, viewModel)
        {
            _vm = viewModel;
        }
        public override void Execute()
        {
            Customer obj = new Customer();
            bool found = false;
            foreach (KeyValuePair<int, Customer> i in CustomerCatalog.Instance.Data)
            {
                if (i.Value.Phone == _vm.Phone)
                {
                    _vm.CustomerId = i.Key;
                    _vm.Name = i.Value.Name;
                    _vm.Stamps = i.Value.Stamps;

                    found = true;
                }            }
            if (!found)
            {
                throw new NotImplementedException();
            }
            
        }
        public override bool CanExecute()
        {
            return base.CanExecute();
        }

        public override void ExecuteEvent()
        {
        }

        public event EventHandler CanExecuteChanged;


    }
}
