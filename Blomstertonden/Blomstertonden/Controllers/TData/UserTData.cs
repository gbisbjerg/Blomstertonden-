using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class UserTData : IKey<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int FK_Role { get; set; }

        public int Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
