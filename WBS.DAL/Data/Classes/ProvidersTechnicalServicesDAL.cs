using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class ProvidersTechnicalServicesDAL : AbstractDAL<ProvidersTechnicalService>
    {
        public ProvidersTechnicalServicesDAL(WBSContext context, ICache cache): base(context, cache)
        { }

        protected override ProvidersTechnicalService GetItem(object id)
        {
            return _context.ProvidersTechnicalServices
                    .Where(p => p.Id == (int)id)
                    .Include(p => p.Provider)
                    .Include(p => p.TechnicalService)
                    .FirstOrDefault();
        }

        protected override IEnumerable<ProvidersTechnicalService> GetItems()
        {
            return _context.ProvidersTechnicalServices
                .Include(p => p.Provider)
                .Include(p => p.TechnicalService)
                .OrderBy(item => item.Id)
                .ToList();
        }
    }
}
