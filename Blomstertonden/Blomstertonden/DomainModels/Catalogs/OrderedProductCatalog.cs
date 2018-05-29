using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderedProductCatalog : AppCatalogBase<OrderedProduct, OrderedProductTData, int>
    {
        public List<OrderedProductTData> _orderedProductTDataList;

        private static OrderedProductCatalog _instance;

        public OrderedProductCatalog( string apiId) : base(new OrderedProductFactory(), apiId)
        {
            _orderedProductTDataList = new List<OrderedProductTData>();
            //Load();
        }

        public static OrderedProductCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderedProductCatalog("OrderedProducts");
                }
                return _instance;
            }
        }

        public async void DeleteOrdersOP(int _orderNumber)
        {
            foreach (OrderedProduct op in _data.Values)
            {
                if(op.FK_Order == _orderNumber)
                {
                    await Delete(op.Key);
                }
            }
        }

        public List<OrderedProductTData> OPTDataList { get => _orderedProductTDataList; set => _orderedProductTDataList = value; }
    }
}
