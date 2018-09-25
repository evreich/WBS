using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Helpers;

namespace WBS.DAL.Layers.Classes
{
    public class CrudCache<T> : ICRUDCache<T> where T: class, IBaseEntity
    {
        ICRUD<T> _crud;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _expiration;
        private string _allIdentifier { get => "all"; }

        public CrudCache(GetCRUD getcrud, IMemoryCache cache, GetExpirationTime getexptime)
        {
            _crud = getcrud(typeof(ICRUDCache<>), typeof(T)) as ICRUD<T>;
            _cache = cache;
            _expiration = getexptime();
        }

        public T Create(T item)
        {
            var data = _crud.Create(item);
            var key = GenerateKey(data.Id.ToString());
            _cache.Set(key, data, _expiration);
            DropAll();
            return item;
        }

        public T Delete(object id)
        {
            var key = GenerateKey(id.ToString());
            var data = _crud.Delete(id);
            if(data != null)
            {
                _cache.Remove(id);
                DropAll();
            }
            return data;
        }

        public IEnumerable<T> Get()
        {
            var key = GenerateKey(_allIdentifier);
            var requested = _cache.Get<IEnumerable<T>>(key);
            if (requested == null)
            {
                requested = _crud.Get();
                if (requested != null && requested.Any())
                    _cache.Set(key, requested.ToList(), _expiration);
            }
            return requested;
        }

        public T Get(object id)
        {
            var key = GenerateKey(id.ToString());
            var requested = _cache.Get<T>(key);
            if(requested == null)
            {
                requested = _crud.Get(id);
                if (requested != null)
                    _cache.Set(key, requested, _expiration);
            }
            return requested;
        }

        public IEnumerable<T> Get(List<Filter> filters, Sort sort)
        {
            var key = GenerateKey(_allIdentifier);
            var requested = _cache.Get<IEnumerable<T>>(key);
            if (requested == null)
            {
                requested = _crud.Get();
                if (requested != null && requested.Any())
                    _cache.Set(key, requested.ToList(), _expiration);
            }
            return Filter(requested, filters, sort);
        }

        private IEnumerable<T> Filter(IEnumerable<T> data, List<Filter> filters, Sort sort)
        {
            var res = QueryHelper.ApplyConditions(data, filters);
            res = QueryHelper.ApplySort(data, sort);
            return res;
        }

        public T Update(T item)
        {
            var data = _crud.Update(item);
            var key = GenerateKey(item.Id.ToString());
            if(data != null)
            {
                _cache.Set(key, data, _expiration);
                DropAll();
            }
            return data;
        }

        private string GenerateKey(string id)
        {
            return $"{typeof(T).FullName}_{id}";
        }

        private void DropAll()
        {
            var key = GenerateKey(_allIdentifier);
            _cache.Remove(key);
        }
    }
}
