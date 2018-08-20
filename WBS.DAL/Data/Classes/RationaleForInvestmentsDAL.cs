using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class RationaleForInvestmentsDAL : AbstractDAL<RationaleForInvestment>
    {
        public RationaleForInvestmentsDAL(WBSContext context, ICache cache) : base(context, cache)
        { }

        protected override RationaleForInvestment GetItem(object id)
        {
            return _context.RationaleForInvestments
                .Where(p => p.Id == (int)id)
                .FirstOrDefault();
        }

        protected override IEnumerable<RationaleForInvestment> GetItems()
        {
            return _context.RationaleForInvestments.ToList();
        }
    }
}
