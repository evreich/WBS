﻿using System;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Data.Models;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Layers.Classes
{
    public class BaseDAL<T>: IDAL<T> where T : class, IBaseEntity
    {
        protected readonly WBSContext _context;
        protected readonly IExtensionDALIQueryable<T> _queryable;

        public BaseDAL(IExtensionDALIQueryable<T> queryable, WBSContext context)
        {
            _queryable = queryable;
            _context = context;
        }

        public T Create(T item)
        {
            var result = _context.Set<T>().Add(item);
            _context.SaveChanges();
            result.Reload();
            var conversionResult = result.Entity;
            return conversionResult;
        }

        public T Get(object id)
        {
            if (_queryable != null)
            {
                var item = _queryable.GetItems(_context.Set<T>()).FirstOrDefault(b => b.Id == (int)id);
                return item;
            }
            else
            {
                return _context.Set<T>().Where(b => b.Id == (int)id).FirstOrDefault();
            }
        }

        public IEnumerable<T> Get()
        {
            if(_queryable != null)
            {
                var items = _queryable.GetItems(_context.Set<T>());
                return items;
            }
            else
            {
                return _context.Set<T>();
            }
        }

        public IEnumerable<T> Get(List<Filter> filters, Sort sort)
        {
            IEnumerable<T> data = this.Get();
            data = QueryHelper.ApplyConditions(data, filters);
            data = QueryHelper.ApplySort(data, sort);
            return data;
        }

        public T Update(T item)
        {
            _context.Set<T>().Update(item);
            _context.SaveChanges();
            if(_queryable != null)
            {
                var result = _queryable.GetItems(_context.Set<T>().Where(b => b.Id == item.Id)).FirstOrDefault();
                return result;
            }
            else
            {
                var result = _context.Set<T>().Where(b => b.Id == item.Id).FirstOrDefault();
                return result;
            }
        }

        public T Delete(object id)
        {
            T item;
            if (_queryable != null)
            {
                item = _queryable.GetItems(_context.Set<T>().Where(b => b.Id == (int)id)).FirstOrDefault();
            }
            else
            {
                item = _context.Set<T>().Where(b => b.Id == (int)id).FirstOrDefault();
            }
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
            return item;
        }
    }
}
