namespace WebService4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderedProduct")]
    public partial class OrderedProduct
    {
        public int Id { get; set; }

 
        public int FK_Order { get; set; }

        public int FK_Product { get; set; }

  
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
