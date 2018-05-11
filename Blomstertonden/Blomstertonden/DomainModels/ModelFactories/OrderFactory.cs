using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class OrderFactory : IFactory<OrderTData, Order>
    {
        public Order Convert(OrderTData data)
        {
            Order obj = new Order
            {
                Description = data.Description,
                Date = data.Date,
                DeliveryDate = data.DeliveryDate,
                Street = data.Street,
                TotalPrice = data.TotalPrice,
                CardMessage = data.CardMessage,
                FK_Customer = data.FK_Customer,
                FK_PaymentType = data.FK_PaymentType,
                FK_City = data.FK_City,
                FK_Status = data.FK_Status
            };
            return obj;
        }
    }
}
