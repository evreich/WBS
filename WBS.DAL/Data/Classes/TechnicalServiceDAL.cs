using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class TechnicalServiceDAL : AbstractDAL<TechnicalService>
    {
        public TechnicalServiceDAL(WBSContext context, ICache cache): base(context,cache)
        { }

        protected override TechnicalService GetItem(object id)
        {
            return _context.TechnicalServices
                .Where(p => p.Id == (int)id)
                .FirstOrDefault();
        }

        protected override IQueryable<TechnicalService> GetItems()
        {
            return _context.TechnicalServices;
        }
    }
}
