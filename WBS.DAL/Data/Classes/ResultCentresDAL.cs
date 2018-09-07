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
    public class ResultCentresDAL : ICRUD<ResultCenter>
    {
        ICRUD<ResultCenter> _result_centers_crud;

        public ResultCentresDAL(GetCRUD getcrud)
        {
            _result_centers_crud = getcrud(typeof(ResultCentresDAL), typeof(ResultCenter)) as ICRUD<ResultCenter>;
        }

        public ResultCenter Create(ResultCenter item)
        {
            return _result_centers_crud.Create(item);
        }

        public ResultCenter Delete(object id)
        {
            return _result_centers_crud.Delete(id);
        }

        public IEnumerable<ResultCenter> Get()
        {
            return _result_centers_crud.Get();
        }

        public ResultCenter Get(object id)
        {
            return _result_centers_crud.Get(id);
        }

        public ResultCenter Update(ResultCenter item)
        {
            return _result_centers_crud.Update(item);
        }
    }
}
