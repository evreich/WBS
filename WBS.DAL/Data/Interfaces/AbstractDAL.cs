using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBS.DAL.Cache;

namespace WBS.DAL
{
    public abstract class AbstractDAL<T> where T : class, IBaseEntity
    {
        protected readonly WBSContext _context;
        protected readonly ICache _cache;

        public AbstractDAL(WBSContext context, ICache cache)
        {
            _context = context;
            _cache = cache;
        }

        protected abstract List<T> GetItems();
        protected abstract T GetItem(object id);

        public virtual T Create(T item)
        {
            var result = _context.Set<T>().Add(item);
            _context.SaveChanges();
            result.Reload();
            var conversionResult = result.Entity;
            _cache.Add(conversionResult);
            return conversionResult;
        }

        public virtual T Get(object id)
        {
            return _cache.Get(id, x => GetItem(id));
        }

        public virtual IEnumerable<T> Get()
        {
            return _cache.Get(_cache.AllIdentifier, param => GetItems());
        }

        public virtual T Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
            var result = GetItem(item.Id);
            _cache.Add(result);
            return result;
        }

        public virtual T Delete(object id)
        {
            //TODO: Analize and refactoring
            var item = _context.Set<T>().Find(id);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
                _cache.Remove(item);
            }
            else
            {
                throw new ArgumentNullException();
            }
            return item;
        }
    }
}
