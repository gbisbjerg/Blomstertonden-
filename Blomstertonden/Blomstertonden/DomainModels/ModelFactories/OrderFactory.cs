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
            Order obj = new Order();
            obj.Description = data.Description;
            obj.Date = data.Date;
            obj.DeliveryDate = data.DeliveryDate;
            obj.Street = data.Street;
            obj.TotalPrice = data.TotalPrice;
            obj.CardMessage = data.CardMessage;
            obj.FK_Customer = data.FK_Customer;
            obj.FK_PaymentType = data.FK_PaymentType;
            obj.FK_City = data.FK_City;
            obj.FK_Status = data.FK_Status;
            return obj;
        }
    }
}
