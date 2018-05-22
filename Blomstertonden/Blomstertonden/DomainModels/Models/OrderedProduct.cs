using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Windows.UI.Xaml.Media;
using GenericsLibrary;

namespace Blomstertonden
{
    [Table("OrderedProduct")]
    public partial class OrderedProduct : IKey<Tuple<int , int>>
    {
        private Tuple<int, int> _composite;

        public OrderedProduct()
        {
            _composite = new Tuple<int, int>(FK_Order, FK_Product);
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_Order { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FK_Product { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
        public Tuple<int, int> Key
        {
            get => _composite = new Tuple<int, int>(FK_Order, FK_Product);
            set => _composite = value;
        }
    }
}
