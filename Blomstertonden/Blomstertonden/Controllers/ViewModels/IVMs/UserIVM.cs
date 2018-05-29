using GenericsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    class UserIVM : ItemViewModelBase<User, int>
    {
        public UserIVM(User obj) : base(obj)
        {
        }
        //properties for list view...
        public string Name
        {
            get => Obj.Name;
        }
        public string Role
        {
            get => RoleCatalog.Instance.GetRole( Obj.FK_Role ).Name;
        }
    }
}
