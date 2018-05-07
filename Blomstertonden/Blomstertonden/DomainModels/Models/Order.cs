using System.Linq;
using GenericsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blomstertonden
{
    [Table("Order")]
    public partial class Order : IKey<int>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderedProducts = new HashSet<OrderedProduct>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
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

        public virtual City City { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }
        public int Key { get => Id; set => Id = value; }
    }
}
