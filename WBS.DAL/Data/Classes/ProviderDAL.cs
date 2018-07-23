using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;

namespace WBS.DAL
{
    public class ProviderDAL : AbstractDAL<Provider>
    {
        public ProviderDAL(WBSContext context, ICache cache) : base(context, cache) { }      

        protected override IEnumerable<Provider> GetItems()
        {
            return _context.Providers.Include(p => p.ProvidersTechnicalServices).ThenInclude(ts => ts.TechnicalService).ToList();
        }

        protected override Provider GetItem(object id)
        {
            return _context.Providers.FirstOrDefault(p => p.Id == (int)id);
        }
    }
}
