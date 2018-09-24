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
    public class TypesOfInvestmentDAL : ICRUD<TypeOfInvestment>
    {
        ICRUD<TypeOfInvestment> _types_of_inv_crud;

        public TypesOfInvestmentDAL(GetCRUD getcrud)
        {
            _types_of_inv_crud = getcrud(typeof(TypesOfInvestmentDAL), typeof(TypeOfInvestment)) as ICRUD<TypeOfInvestment>;
        }

        public TypeOfInvestment Create(TypeOfInvestment item)
        {
            return _types_of_inv_crud.Create(item);
        }

        public TypeOfInvestment Delete(object id)
        {
            return _types_of_inv_crud.Delete(id);
        }

        public IEnumerable<TypeOfInvestment> Get()
        {
            return _types_of_inv_crud.Get();
        }

        public TypeOfInvestment Get(object id)
        {
            return _types_of_inv_crud.Get(id);
        }

        public IEnumerable<TypeOfInvestment> Get(List<Filter> filters, Sort sort)
        {
            return _types_of_inv_crud.Get(filters, sort);
        }

        public TypeOfInvestment Update(TypeOfInvestment item)
        {
            return _types_of_inv_crud.Update(item);
        }
    }
}
