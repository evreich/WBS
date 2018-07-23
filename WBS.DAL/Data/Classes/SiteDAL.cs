using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class SiteDAL : AbstractDAL<Site>
    {
        public SiteDAL(WBSContext context, ICache cache) : base(context, cache) { }

        protected override IEnumerable<Site> GetItems()
        {
            return _context.Sites
                .Include(s => s.CreaterOfBudget)
                .Include(s => s.DirectorOfSit)
                .Include(s => s.Format)
                .Include(s => s.KyRegion)
                .Include(s => s.KySit)
                .Include(s => s.OperationDirector)
                .Include(s => s.TechnicalExpert)
                .ToList();
        }

        protected override Site GetItem(object id)
        {
            return _context.Sites
                .Include(s => s.CreaterOfBudget)
                .Include(s => s.DirectorOfSit)
                .Include(s => s.Format)
                .Include(s => s.KyRegion)
                .Include(s => s.KySit)
                .Include(s => s.OperationDirector)
                .Include(s => s.TechnicalExpert)
                .FirstOrDefault(item => item.Id == (int)id);
        }
    }
}
