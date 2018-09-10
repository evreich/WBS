using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using System;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class ExtensionDALIQueryableProvider : IExtensionDALIQueryable<Provider>
    {
        public IQueryable<Provider> GetItems(IQueryable<Provider> query)
        {
            return query.Include(p => p.ProvidersTechnicalServices).ThenInclude(ts => ts.TechnicalService);
        }
    }

    public class ProviderDAL : ICRUD<Provider>
    {
        ICRUD<Provider> _providers_crud;

        public ProviderDAL(GetCRUD getcrud)
        {
            _providers_crud = getcrud(typeof(ProviderDAL), typeof(Provider)) as ICRUD<Provider>;
        }

        public Provider Create(Provider item)
        {
            return _providers_crud.Create(item);
        }

        public Provider Delete(object id)
        {
            return _providers_crud.Delete(id);
        }

        public IEnumerable<Provider> Get()
        {
            return _providers_crud.Get();
        }

        public Provider Get(object id)
        {
            return _providers_crud.Get(id);
        }

        public Provider Update(Provider item)
        {
            return _providers_crud.Update(item);
        }
    }
}
