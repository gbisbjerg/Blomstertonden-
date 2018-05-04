using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class Product : IKey<int>
    {
        private int _id;
        private string _name;
        private int _price;
        private bool _isPromotional;

        public int Key
        {
            get => _id;
            set { _id = value; }
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsPromotional { get; set; }
    }
}
