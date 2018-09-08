using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class ExtensionDALIQueryableFormat : IExtensionDALIQueryable<Format>
    {
        public IQueryable<Format> GetItems(IQueryable<Format> query)
        {
            return query.Include(f => f.DirectorOfFormat)
                .Include(f => f.DirectorOfKYFormat)
                .Include(f => f.KYFormat);
        }
    }

    public class FormatDAL : ICRUD<Format>
    {
        ICRUD<Format> _formats_crud;

        public FormatDAL(GetCRUD getcrud)
        {
            _formats_crud = getcrud(typeof(FormatDAL), typeof(Format)) as ICRUD<Format>;
        }

        public Format Create(Format item)
        {
            return _formats_crud.Create(item);
        }

        public Format Delete(object id)
        {
            return _formats_crud.Delete(id);
        }

        public IEnumerable<Format> Get()
        {
            return _formats_crud.Get();
        }

        public Format Get(object id)
        {
            return _formats_crud.Get(id);
        }

        public Format Update(Format item)
        {
            return _formats_crud.Update(item);
        }
    }
}
