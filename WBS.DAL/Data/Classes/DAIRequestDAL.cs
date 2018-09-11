using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using System;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL
{
    public class ExtensionDALIQueryableDAIRequest : IExtensionDALIQueryable<DAIRequest>
    {
        public IQueryable<DAIRequest> GetItems(IQueryable<DAIRequest> query)
        {
            return query.Include(d => d.Sit)
                .Include(d => d.ResultCentre)
                .Include(d => d.DAIRequestsProviders)
                    .ThenInclude(dp => dp.Provider)
                .Include(d => d.DAIRequestsTechnicalService)
                    .ThenInclude(dt => dt.TechnicalServ);
        }
    }

    public class DAIRequestDAL : ICRUD<DAIRequest>
    {
        ICRUD<DAIRequest> _dai_requests_crud;
        ICRUD<DAIRequestsTechnicalService> _dai_requests_tech_services_crud;

        public DAIRequestDAL(GetCRUD getcrud)
        {
            _dai_requests_crud = getcrud(typeof(DAIRequestDAL), typeof(DAIRequest)) as ICRUD<DAIRequest>;
            _dai_requests_tech_services_crud = getcrud(typeof(DAIRequestDAL), typeof(DAIRequestsTechnicalService)) as ICRUD<DAIRequestsTechnicalService>;
        }


        public void AddTechnicalServs(int requestId, List<TechnicalServiceViewModel> servs)
        {
            var techServs = new List<DAIRequestsTechnicalService>();
            foreach (var t in servs)
            {
                techServs.Add(new DAIRequestsTechnicalService { DaiId = requestId, TechnicalServId = t.Id });
            }
            foreach(var service in techServs)
            {
                _dai_requests_tech_services_crud.Create(service);
            }
        }

        public DAIRequest Create(DAIRequest item)
        {
            return _dai_requests_crud.Create(item);
        }

        public DAIRequest Delete(object id)
        {
            return _dai_requests_crud.Delete(id);
        }

        public IEnumerable<DAIRequest> Get()
        {
            return _dai_requests_crud.Get();
        }

        public DAIRequest Get(object id)
        {
            return _dai_requests_crud.Get(id);
        }

        public DAIRequest Update(DAIRequest item)
        {
            return _dai_requests_crud.Update(item);
        }
    }
}
