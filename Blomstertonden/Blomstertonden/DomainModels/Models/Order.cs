using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class Order : IKey<int>
    {
        private int _id;
        private string _description;
        private DateTime _date;
        private DateTime _deliveryDate;
        private string _cardMessage;
        public int Key { get; set; }
    }
}
