﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLibrary
{
    public abstract class CatalogBaseDB<TData, T, TKey> : ICRUD<T, TData, TKey>
        where T : IKey<TKey>
        where TData : IKey<TKey>, new()
    {
        protected Dictionary<TKey, T> _data;
        protected IFactory<TData, T> _factory;
        protected IDBSource<T, TKey> _dataSource;
        protected TData _dataPackage;

        protected CatalogBaseDB(IFactory<TData, T> factory, string serverURL, string apiId)
        {
            _dataSource = new DBSource<T, TKey>(serverURL, apiId);
            _factory = factory;
            _data = new Dictionary<TKey, T>();
            _dataPackage = new TData();
        }
        public TData DataPackage
        {
            get => _dataPackage;
            set => _dataPackage = value;
        }
        public List<T> All => _data.Values.ToList();
        public Dictionary<TKey, T> Data => _data;

        public async void Load()
        {
            List<T> data = await _dataSource.Load();
            foreach (T t in data)
            {
                _data.Add(t.Key, t);
            }
        }
        public virtual async Task Create(TData data, bool nextKey)
        {
            T obj = _factory.Convert(data);
            if (nextKey)
            {
                TKey newKey = NextKey();
                obj.Key = newKey;
            }
            await _dataSource.Create(obj);
            T dbObj = await Read(obj.Key);
            _data.Add(dbObj.Key, dbObj);
        }
        public virtual async Task Create(TData data)
        {
            T obj = _factory.Convert(data);
            await _dataSource.Create(obj);
            T dbObj = await Read(obj.Key);
            _data.Add(dbObj.Key, dbObj);
        }
        public async Task<T> Read(TKey key)
        {
            return await _dataSource.Read(key);
        }
        public virtual async Task Update(TData data)
        {
            T obj = _factory.Convert(data);
            await _dataSource.Update(obj);
            _data.Remove(obj.Key);
            T dbObj = await Read(obj.Key);
            _data.Add(dbObj.Key, dbObj);
        }
        public virtual async Task Delete(TKey key)
        {
            await _dataSource.Delete(key);
            _data.Remove(key);
        }
        public abstract TKey NextKey();

    }
}
