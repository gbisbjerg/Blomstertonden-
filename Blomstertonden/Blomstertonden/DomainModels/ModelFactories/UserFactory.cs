using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden
{
    class UserFactory : IFactory<UserTData, User>
    {
        public User Convert(UserTData data)
        {
            User obj = new User
            {
                Id = data.Key,
                Name = data.Name,
                Password = data.Password,
                FK_Role = data.FK_Role
            };
            return obj;
        }
    }
}
