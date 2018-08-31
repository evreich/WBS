using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WBS.DAL.Data.Classes
{
    public class EventsDAL: AbstractDAL<Event>
    {
        public EventsDAL(WBSContext context, ICache cache) : base(context, cache)
        {
        }

        protected override Event GetItem(object id)
        {
            return _context.Events
                .Include(item => item.BudgetPlan)
                .Include(item => item.Status)
                .Include(item => item.EventQuarters)
                    .ThenInclude(items => items.QuarterOfYear)
                .FirstOrDefault(item => item.Id == (int)id);
        }

        protected override IEnumerable<Event> GetItems()
        {
            return _context.Events
                .Include(item => item.BudgetPlan)
                .Include(item => item.Status)
                .ToList();
        }
    }
}
