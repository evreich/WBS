using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class ExtensionDALIQueryableSite : IExtensionDALIQueryable<Site>
    {
        public IQueryable<Site> GetItems(IQueryable<Site> query)
        {
            return query
                .Include(s => s.CreaterOfBudget)
                .Include(s => s.DirectorOfSit)
                .Include(s => s.Format)
                .Include(s => s.KyRegion)
                .Include(s => s.KySit)
                .Include(s => s.OperationDirector)
                .Include(s => s.TechnicalExpert);
        }
    }
    public class SiteDAL : ICRUD<Site>
    {
        ICRUD<Site> _sites_crud;

        public SiteDAL(GetCRUD getcrud)
        {
            _sites_crud = getcrud(typeof(SiteDAL), typeof(Site)) as ICRUD<Site>;
        }

        public Site Create(Site item)
        {
            return _sites_crud.Create(item);
        }

        public Site Delete(object id)
        {
            return _sites_crud.Delete(id);
        }

        public IEnumerable<Site> Get()
        {
            return _sites_crud.Get();
        }

        public Site Get(object id)
        {
            return _sites_crud.Get(id);
        }

        public Site Update(Site item)
        {
            return _sites_crud.Update(item);
        }
    }
}
