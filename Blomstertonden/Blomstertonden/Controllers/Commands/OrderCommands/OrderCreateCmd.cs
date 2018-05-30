using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Blomstertonden
{
    class OrderCreateCmd : CreateCommandBase<OrderTData, Order, int>
        
    {
        private CustomerCatalog _customerCatalog;
        private OrderedProductCatalog _orderedProductCatalog;
        private OrderMDVM _vm;

        public OrderCreateCmd(ICRUD<Order, OrderTData, int> catalog, OrderMDVM viewModel) : base(OrderCatalog.Instance, viewModel)
        {
            _customerCatalog = CustomerCatalog.Instance;
            _orderedProductCatalog = OrderedProductCatalog.Instance;
            _vm = viewModel;
        }

        public override async void Execute()
        {
            //Creates new customer or uses existing. 
            if (_customerCatalog.DataPackage.Key == 0)
            {
                _catalog.DataPackage.FK_Customer = await _customerCatalog.Create(_customerCatalog.DataPackage);
                _customerCatalog.DataPackage.Key = _catalog.DataPackage.FK_Customer;
            }
            else
            {
                _catalog.DataPackage.FK_Customer = _customerCatalog.DataPackage.Key;
            }


            //delete when implemented through catalog
            _catalog.DataPackage.FK_Status = 1;
            //

            //Sets creation time to current
            _catalog.DataPackage.Date = DateTime.Now;
            
            //if no city is set will to default
            if (_catalog.DataPackage.FK_City == null)
            {
                _catalog.DataPackage.FK_City = 0;
            }

            //Creates the order
            int Orderkey =  await _catalog.Create(_catalog.DataPackage);

            //Check if stamps need to be applied
            if (OrderCatalog.Instance.QualifyStamp(Orderkey))
            {
                _customerCatalog.AddStamp(_customerCatalog.DataPackage);
            }

            //Creates the OrderedProducts
            foreach (OrderedProductTData opTData in _orderedProductCatalog.OPTDataList)
            {
                opTData.FK_Order = Orderkey;
                if (opTData.Quantity <= 0)
                {
                    opTData.Quantity = 1;
                }

                await _orderedProductCatalog.Create(opTData);
            }

            //Wipes ORderedProducts
            _vm.AddedProducts = new ObservableCollection<OrderedProductTData>();
            ExecuteEvent();


        }
    }
}
