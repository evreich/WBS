using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using System;

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

        //TODO: Refactoring after analize AbstractDAL realization
        public override Provider Delete(object id)
        {
            var item = _context.Providers
                .Include(prov => prov.ProvidersTechnicalServices)
                .Single(elem => elem.Id == (int)id);

            if (item != null)
            {
                _context.Providers.Remove(item);
                _context.SaveChanges();
                _cache.Remove(item);
            }
            else
            {
                throw new ArgumentNullException();
            }
            return item;
        }

        public override Provider Update(Provider item)
        {
            var currProvider = _context.Providers
                .Include(prov => prov.ProvidersTechnicalServices)
                .Single(elem => elem.Id == item.Id);

            _context.Entry(currProvider).CurrentValues.SetValues(item);

            currProvider.ProvidersTechnicalServices.RemoveRange(0, currProvider.ProvidersTechnicalServices.Count);
            currProvider.ProvidersTechnicalServices.AddRange(item.ProvidersTechnicalServices.ToList());

            _context.Entry(currProvider).State = EntityState.Modified;
            _context.SaveChanges();

            _cache.Add(currProvider);
            return currProvider;
        }
    }
}
