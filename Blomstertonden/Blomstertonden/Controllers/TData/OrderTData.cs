using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blomstertonden
{
    public class OrderTData : IKey<int>
    {
        public List<Product> _orderProducts;
        public OrderTData()
        {
            _orderProducts = new List<Product>();
            Product p1 = new Product();
            p1.Name = "Testing";
            p1.Price = 600;

            _orderProducts.Add(p1);
        }

        public int Key { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        public int TotalPrice { get; set; }

        [StringLength(500)]
        public string CardMessage { get; set; }

        public int FK_Customer { get; set; }

        public int? FK_PaymentType { get; set; }

        public int? FK_City { get; set; }

        public int FK_Status { get; set; }

        public List<Product> Order_Products
        {
            get { return _orderProducts; }
            set { _orderProducts = value; }
        }
    }
}
