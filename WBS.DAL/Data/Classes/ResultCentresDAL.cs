using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class ResultCentresDAL : AbstractDAL<ResultCenter>
    {
        public ResultCentresDAL(WBSContext context, ICache cache) : base(context, cache) { }

        protected override List<ResultCenter> GetItems()
        {
            return _context.ResultCentres.ToList();
        }

        protected override ResultCenter GetItem(object id)
        {
            return _context.ResultCentres.FirstOrDefault(x => x.Id == (int)id);
        }
    }
}
