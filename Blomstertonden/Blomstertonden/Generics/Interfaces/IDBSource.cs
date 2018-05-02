using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLibrary
{
    public interface IDBSource<T, TKey>
    {
        Task Create(T obj);
        Task<T> Read(TKey key);
        Task Update(T obj);
        Task Delete(TKey key);
        Task<Dictionary<TKey, T>> Load();
    }
}
