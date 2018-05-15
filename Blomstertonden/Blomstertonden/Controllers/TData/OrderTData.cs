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
        public int Key { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        public int TotalPrice { get; set; }

        [StringLength(500)]
        public string CardMessage { get; set; }

        public Customer Customer { get; set; }

        public int FK_Customer { get; set; }

        public int? FK_PaymentType { get; set; }

        public int? FK_City { get; set; }

        public int FK_Status { get; set; }

        public virtual City City { get; set; }

        //public virtual Customer Customer { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual Status Status { get; set; }
    }
}
