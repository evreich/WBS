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
using WBS.DAL.Data.Helpers;

namespace WBS.DAL
{
    public class RationaleForInvestmentsDAL : ICRUD<RationaleForInvestment>
    {

        ICRUD<RationaleForInvestment> _rationalies_for_inv_crud;

        public RationaleForInvestmentsDAL(GetCRUD getcrud)
        {
            _rationalies_for_inv_crud = getcrud(typeof(RationaleForInvestmentsDAL), typeof(RationaleForInvestment)) as ICRUD<RationaleForInvestment>;
        }

        public RationaleForInvestment Create(RationaleForInvestment item)
        {
            return _rationalies_for_inv_crud.Create(item);
        }

        public RationaleForInvestment Delete(object id)
        {
            return _rationalies_for_inv_crud.Delete(id);
        }

        public IEnumerable<RationaleForInvestment> Get()
        {
            return _rationalies_for_inv_crud.Get();
        }

        public RationaleForInvestment Get(object id)
        {
            return _rationalies_for_inv_crud.Get(id);
        }

        public IEnumerable<RationaleForInvestment> Get(List<Filter> filters, Sort sort)
        {
            return _rationalies_for_inv_crud.Get(filters, sort);
        }

        public RationaleForInvestment Update(RationaleForInvestment item)
        {
            return _rationalies_for_inv_crud.Update(item);
        }
    }
}
