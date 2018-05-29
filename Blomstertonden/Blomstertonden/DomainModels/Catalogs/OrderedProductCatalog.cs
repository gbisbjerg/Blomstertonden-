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
            Load();
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
            List<int> KeysToRemove = new List<int>();
            foreach (OrderedProduct op in _data.Values)
            {
                if(op.FK_Order == _orderNumber)
                {
                    KeysToRemove.Add(op.Key);
                }
            }
            foreach (int key in KeysToRemove)
            {
                await Delete(key);
            }
            
        }

        public List<OrderedProductTData> OPTDataList { get => _orderedProductTDataList; set => _orderedProductTDataList = value; }
    }
}
