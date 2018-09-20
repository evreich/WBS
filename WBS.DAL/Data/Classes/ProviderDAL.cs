using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using System;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;
using WBS.DAL.Data.Models;

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
        ICRUD<ProvidersTechnicalService> _providers_techServs_crud;

        public ProviderDAL(GetCRUD getcrud, ICRUD<ProvidersTechnicalService> providers_techServs_crud)
        {
            _providers_crud = getcrud(typeof(ProviderDAL), typeof(Provider)) as ICRUD<Provider>;
            _providers_techServs_crud = providers_techServs_crud;
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
            //чистим свзяанные сущности
            _providers_crud.Get(item.Id).ProvidersTechnicalServices
                .ForEach(elem => _providers_techServs_crud.Delete(elem.Id));
            //добавляем новые сущности в связь
            item.ProvidersTechnicalServices.ForEach(elem => _providers_techServs_crud.Create(elem));

            return _providers_crud.Update(item);
        }
    }
}
