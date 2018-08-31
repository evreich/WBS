using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace WBS.DAL.Cache
{
    public class WBSMemoryCache : ICache
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _expiration;

        //TODO: Проблема с изменением и удалением записей в кеше связана с идентификатором данных в кеше.
        //Кеш либо не находит данные в своем хранилище, либо его логика в принципе не верна
        //Скорее всего, требуется убедится в том, что ИД изменяемых данных и соотв хранимых в кеше данных совпадает

        public string AllIdentifier { get => "all"; }
        public string GenerateKey<T>(string id)
        {
            return $"{typeof(T).FullName}_{id}";
        }

        public WBSMemoryCache(IMemoryCache instance, TimeSpan relativeExpiration)
        {
            _cache = instance;
            _expiration = relativeExpiration;
        }

        public void Add<T>(T data) where T : IBaseEntity
        {
            if (data != null)
            {
                _cache.Set(GenerateKey<T>(data.Id.ToString()), data, _expiration);
                DropAll<T>();
            }
        }

        public void Add<T>(string id, T data)
        {
            if (data != null)// если объект не пустой
            {
                var isIEnum = data as IEnumerable<object>;
                if (isIEnum == null || isIEnum.Count() > 0)// если перечисление то проверяем кол-во
                {
                    _cache.Set(GenerateKey<T>(id), data, _expiration);
                    DropAll<T>();
                }
            }
        }

        public T Get<T>(object id, Func<object, T> extractFromDb = null)
        {
            var requested = _cache.Get<T>(GenerateKey<T>(id.ToString()));
            if (extractFromDb != null && requested == null)
            {
                requested = extractFromDb(id);
                if (requested != null)
                    Add(id.ToString(), requested);
            }
            return requested;
        }

        public void Remove<T>(T data) where T : IBaseEntity
        {
            _cache.Remove(GenerateKey<T>(data.Id.ToString()));
            DropAll<T>();
        }

        public void Remove<T, TId>(TId id)
        {
            _cache.Remove(GenerateKey<T>(id.ToString()));
            DropAll<T>();
        }

        public void DropAll<T>()
        {
            var allKey = GenerateKey<IEnumerable<T>>(AllIdentifier);
            _cache.Remove(allKey);
        }
    }
}
