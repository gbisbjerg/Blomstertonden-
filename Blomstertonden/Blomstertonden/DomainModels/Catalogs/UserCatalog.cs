using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;
namespace Blomstertonden
{
    class UserCatalog : AppCatalogBase<User, UserTData, int>
    {
        private static UserCatalog _instance;

        public UserCatalog(IFactory<UserTData, User> factory, string apiId) : base(factory, apiId)
        {
            Load();
        }

        public static UserCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserCatalog(new UserFactory(), "Users");
                }
                return _instance;
            }
        }
    }
}
