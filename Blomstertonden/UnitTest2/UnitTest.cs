
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blomstertonden;
using System.Threading.Tasks;

namespace UnitTest2
{
    [TestClass]
    public class UnitTest1
    {
        OrderCatalog _orderCatalog = OrderCatalog.Instance;
        CustomerCatalog _customerCatalog = CustomerCatalog.Instance;

        public CustomerTData GenerateCustomerTData()
        {
            CustomerTData customerTData = new CustomerTData();
            customerTData.Name = "Name";
            customerTData.Phone = 111111111;
            customerTData.Stamps = 0;

            return customerTData;
        }
        public async Task<int> GenerateCustomer()
        {
            _customerCatalog.DataPackage = GenerateCustomerTData();
            int CustomerFK = await _customerCatalog.Create(_customerCatalog.DataPackage);
            return CustomerFK;
        }

        public OrderTData GenerateOrderTData(int fk_customer)
        {
            OrderTData orderTData = new OrderTData();
            orderTData.CardMessage = "Card Message";
            orderTData.Date = DateTime.Now;
            orderTData.DeliveryDate = DateTime.Now;
            orderTData.Description = "Description";
            orderTData.FK_Customer = fk_customer;
            orderTData.FK_City = 0;
            orderTData.FK_PaymentType = 1;
            orderTData.FK_Status = 1;
            orderTData.Street = "Street";
            orderTData.TotalPrice = 100;

            return orderTData;
        }
        public async Task<int> GenerateOrder(int CustomerFK)
        {
            _orderCatalog.DataPackage = GenerateOrderTData(CustomerFK);
            int OrderFK = await _orderCatalog.Create(_orderCatalog.DataPackage);
            return OrderFK;
        }

        public async void Clear(int CustomerFK, int OrderFK)
        {
            await _customerCatalog.Delete(CustomerFK);
            await _orderCatalog.Delete(OrderFK);
        }

        [TestMethod]
        public async Task CreateOrder()
        {
            // arrange  
            // act
            int CustomerFK = await GenerateCustomer();
            int OrderFK = await GenerateOrder(CustomerFK);

            // assert  
            Customer customer = await _customerCatalog.Read(CustomerFK);
            Order order = await _orderCatalog.Read(OrderFK);
            Assert.AreEqual(CustomerFK, customer.Key);
            Assert.AreEqual(OrderFK, order.Key);

            Clear(CustomerFK, OrderFK);
        }

        [TestMethod]
        public async Task DeleteOrder()
        {
            // arrange 
            int CustomerFK = await GenerateCustomer();
            int OrderFK = await GenerateOrder(CustomerFK);

            // act
            await _customerCatalog.Delete(CustomerFK);
            await _orderCatalog.Delete(OrderFK);

            // assert  
            Assert.AreEqual(null, _customerCatalog.Read(CustomerFK));
            Assert.AreEqual(null, _orderCatalog.Read(OrderFK));
        }

        [TestMethod]
        public async Task UpdateOrder()
        {
            // arrange 
            int CustomerFK = await GenerateCustomer();
            int OrderFK = await GenerateOrder(CustomerFK);

            CustomerTData customerTData = GenerateCustomerTData();
            OrderTData orderTData = GenerateOrderTData(0);

            customerTData.Name = "New Name";
            orderTData.CardMessage = "New Card";
            // act
            await _customerCatalog.Update(customerTData);
            await _orderCatalog.Update(orderTData);

            // assert  
            Customer customer = await _customerCatalog.Read(CustomerFK);
            Order order = await _orderCatalog.Read(OrderFK);

            Assert.AreEqual("New Name", customer.Name);
            Assert.AreEqual(null, order.CardMessage);

            Clear(CustomerFK, OrderFK);
        }
    }
}
