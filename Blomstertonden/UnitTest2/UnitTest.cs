
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blomstertonden;
using System.Threading.Tasks;

namespace UnitTest2
{
    [TestClass]
    public class UnitTest1
    {

        int _customerFK;
        int _orderFK;
        public UnitTest1()
        {
            _customerFK = GenerateCustomer().Result;
            _orderFK = GenerateOrder(_customerFK).Result;
        }

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

        [TestMethod]
        public void CreateOrder()
        {
            Customer customer = _customerCatalog.Read(_customerFK).Result;
            Order order = _orderCatalog.Read(_orderFK).Result;
            Assert.AreEqual(_customerFK, customer.Key);
            Assert.AreEqual(_orderFK, order.Key);
        }

        [TestMethod]
        public void QualifyStamps()
        {
            Assert.AreEqual(false, _orderCatalog.QualifyStamp(_orderFK));
        }

        [TestMethod]
        public void Stamp()
        {
            Customer _customer;
            _customerCatalog.Data.TryGetValue(_customerFK, out _customer);

            Assert.AreEqual(0, _customer.Stamps);
        }


        [TestMethod]
        public void UpdateOrder()
        {
            CustomerTData customerTData = GenerateCustomerTData();
            OrderTData orderTData = GenerateOrderTData(_customerFK);

            customerTData.Key = _customerFK;
            customerTData.Name = "New Name";
            orderTData.Key = _orderFK;
            orderTData.CardMessage = "New Card";

            _customerCatalog.Update(customerTData).Wait();
            _orderCatalog.Update(orderTData).Wait();

            Order _order;
            _orderCatalog.Data.TryGetValue(_orderFK, out _order);

            Customer _customer;
            _customerCatalog.Data.TryGetValue(_customerFK, out _customer);

            Assert.AreEqual("New Name", _customer.Name);
            Assert.AreEqual("New Card", _order.CardMessage);
        }

        [TestMethod]
        public void DeleteOrder()
        {
            _orderCatalog.Delete(_orderFK).Wait();
            _customerCatalog.Delete(_customerFK).Wait();

            Order _order;
            _orderCatalog.Data.TryGetValue(_orderFK, out _order);

            Customer _customer;
            _customerCatalog.Data.TryGetValue(_customerFK, out _customer);

            Assert.AreEqual(null, _order);
            Assert.AreEqual(null, _customer);
        }


    }
}
