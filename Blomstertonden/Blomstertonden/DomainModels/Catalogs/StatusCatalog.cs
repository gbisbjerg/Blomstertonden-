using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blomstertonden.AppGenerics.DomainBase;

namespace Blomstertonden.DomainModels.Catalogs
{
    class StatusCatalog : ReadOnlyCatalogBase<Status, int>
    {
        public StatusCatalog() : base(AppConfig.ServerURL, "Status")
        {
        }
    }
}
