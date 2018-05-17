using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blomstertonden
{
    public class PaymentTypeCatalog : ReadOnlyCatalogBase<PaymentType, int>
    {
        public List<String> _paymentTypeList;

        private static PaymentTypeCatalog _instance;
        private PaymentTypeCatalog() : base(AppConfig.ServerURL, "PaymentTypes")
        {
        }

        public static PaymentTypeCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PaymentTypeCatalog();
                }
                return _instance;
            }
        }

        public List<PaymentType> PaymentTypeList
        {
            get
            {
                return All.Values.ToList();
            }
        }

    }
}
