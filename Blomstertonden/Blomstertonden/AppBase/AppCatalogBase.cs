using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericsLibrary;

namespace Blomstertonden.AppBase
{
    public class AppCatalogBase<T, TData, TKey> : CatalogBaseDB<TData, T, TKey>
        where T : IKey<TKey> 
        where TData : IKey<TKey>
    {
        public AppCatalogBase(IFactory<TData, T> factory, string apiId) : base(factory, AppConfig.ServerURL, apiId)
        {
        }

        public override TKey NextKey()
        {
            throw new NotImplementedException();
        }
    }
}
