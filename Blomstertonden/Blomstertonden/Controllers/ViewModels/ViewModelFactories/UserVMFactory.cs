using GenericsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    class UserVMFactory : ViewModelFactoryBase<UserTData, User, int>
    {
        public override ItemViewModelBase<User, int> CreateItemViewModel(User obj)
        {
            return new UserIVM(obj);
        }
    }
}
