using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using WBS.DAL.Layers;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class ExtensionDALIQueryableRequestLine : IExtensionDALIQueryable<RequestLine>
    {
        public IQueryable<RequestLine> GetItems(IQueryable<RequestLine> query)
        {
            return query
                .Include(rl => rl.BudgetLine)
                .Include(rl => rl.Request)
                .Include(rl => rl.ResultCenter)
                .Include(rl => rl.CategoryOfEquipment)
                .Include(rl => rl.Site)
                .Include(rl => rl.TypeOfInvestment);
        }
    }

    public class RequestLineDAL : ICRUD<RequestLine>
    {
        ICRUD<RequestLine> _requestLine_crud;

        public RequestLineDAL(GetCRUD getcrud, WBSContext context)
        {
            _requestLine_crud = getcrud(typeof(RequestLineDAL), typeof(RequestLine)) as ICRUD<RequestLine>;
        }

        public RequestLine Create(RequestLine item)
        {
            return _requestLine_crud.Create(item);
        }

        public RequestLine Delete(object id)
        {
            return _requestLine_crud.Delete(id);
        }

        public IEnumerable<RequestLine> Get()
        {
            return _requestLine_crud.Get();
        }

        public RequestLine Get(object id)
        {
            return _requestLine_crud.Get(id);
        }

        public RequestLine Update(RequestLine item)
        {
            return _requestLine_crud.Update(item);
        }
    }
}
