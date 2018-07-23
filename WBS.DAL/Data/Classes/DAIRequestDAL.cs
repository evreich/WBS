using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using System;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.DAL
{
    public class DAIRequestDAL : AbstractDAL<DAIRequest>
    {
        public DAIRequestDAL(WBSContext context, ICache cache) : base(context, cache)
        {

        }

        protected override DAIRequest GetItem(object id)
        {
            return _context.DaiRequests
                .Include(d => d.Sit)
                .Include(d => d.ResultCentre)
                .Include(d => d.DAIRequestsProviders)
                    .ThenInclude(dp => dp.Provider)
                .Include(d => d.DAIRequestsTechnicalService)
                    .ThenInclude(dt => dt.TechnicalServ)
                .FirstOrDefault(d => d.Id == (int)id);
        }

        protected override IEnumerable<DAIRequest> GetItems()
        {
            return _context.DaiRequests
                 .Include(s => s.Sit)
                .Include(s => s.ResultCentre)
                .Include(d => d.DAIRequestsProviders)
                    .ThenInclude(p => p.Provider)
                .Include(d => d.DAIRequestsTechnicalService)
                    .ThenInclude(t => t.TechnicalServ);
        }

        public void AddTechnicalServs(int requestId, List<TechnicalServiceViewModel> servs)
        {
            var techServs = new List<DAIRequestsTechnicalService>();
            foreach (var t in servs)
            {
                techServs.Add(new DAIRequestsTechnicalService { DaiId = requestId, TechnicalServId = t.Id });
            }
            _context.DaiRequestTechnicalServices.AddRange(techServs);
            _context.SaveChanges();
        }
    }
}
