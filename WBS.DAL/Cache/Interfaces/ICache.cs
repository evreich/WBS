using System;
using WBS.DAL.Cache;

namespace WBS.DAL.Cache
{
    public interface ICache
    {
        string AllIdentifier { get; }
        string GenerateKey<T>(string id);

        void Add<T>(T data) where T : IBaseEntity;
        void Add<T>(string key, T data);

        T Get<T>(object id, Func<object, T> extractFromDb = null);

        void Remove<T, TId>(TId id);
        void Remove<T>(T data) where T : IBaseEntity;

        void DropAll<T>();
    }
}
