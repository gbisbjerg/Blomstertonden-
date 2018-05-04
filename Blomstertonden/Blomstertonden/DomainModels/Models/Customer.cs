using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    public class Customer : IKey<int>
    {
        private int _id;
        private string _name;
        private int _phone;
        private int _stamps;

        public int Key
        {
            get => _id;
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public int Stamps
        {
            get { return _stamps; }
            set { _stamps = value; }
        }
    }
}
