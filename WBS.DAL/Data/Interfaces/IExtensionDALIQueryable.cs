using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBS.DAL.Data.Interfaces
{
    public interface IExtensionDALIQueryable<T>
    {
        IQueryable<T> GetItems(IQueryable<T> query);
    }

    public class ExtensionDALIQueryable<T>: IExtensionDALIQueryable<T>
    {
        public IQueryable<T> GetItems(IQueryable<T> query)
        {
            return query;
        }
    }
}
