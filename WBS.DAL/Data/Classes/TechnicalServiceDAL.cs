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
    public class TechnicalServiceDAL : ICRUD<TechnicalService>
    {
        ICRUD<TechnicalService> _technical_services_crud;

        public TechnicalServiceDAL(GetCRUD getcrud)
        {
            _technical_services_crud = getcrud(typeof(TechnicalServiceDAL), typeof(TechnicalService)) as ICRUD<TechnicalService>;
        }

        public TechnicalService Create(TechnicalService item)
        {
            return _technical_services_crud.Create(item);
        }

        public TechnicalService Delete(object id)
        {
            return _technical_services_crud.Delete(id);
        }

        public IEnumerable<TechnicalService> Get()
        {
            return _technical_services_crud.Get();
        }

        public TechnicalService Get(object id)
        {
            return _technical_services_crud.Get(id);
        }

        public TechnicalService Update(TechnicalService item)
        {
            return _technical_services_crud.Update(item);
        }
    }
}
