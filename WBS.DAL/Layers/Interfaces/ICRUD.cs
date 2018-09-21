using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Helpers;

namespace WBS.DAL.Layers.Interfaces
{
    public interface ICRUD<T> where T: class, IBaseEntity
    {
        T Update(T item);
        T Delete(object id);
        T Create(T item);
        IEnumerable<T> Get();
        IEnumerable<T> Get(List<Filter> filters, Sort sort);
        T Get(object Id);
    }
}
