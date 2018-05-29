using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{ 
    class RoleCatalog : ReadOnlyCatalogBase<Role, int>
    {
        private static RoleCatalog _instance;
        private RoleCatalog() : base(AppConfig.ServerURL, "Roles")
        {
        }

        public static RoleCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoleCatalog();
                }
                return _instance;
            }
        }

        public Role GetRole(int fk_role)
        {
            Role role;
            All.TryGetValue(fk_role, out role);
            return role;
        }
    }
}
