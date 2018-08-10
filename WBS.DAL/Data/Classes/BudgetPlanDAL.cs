using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace WBS.DAL.Data.Classes
{
    public class BudgetPlanDAL: AbstractDAL<BudgetPlan>
    {
        public BudgetPlanDAL(WBSContext context, ICache cache): base(context, cache)
        {
        }

        public bool IsAlreadyHaveInDb(int year)
        {
            return _context.BudgetPlans.FirstOrDefault(bp => bp.Year == year) != null;
        }

        protected override BudgetPlan GetItem(object id)
        {
            return _context.BudgetPlans
                .Include(item => item.Items)
                .Include(item => item.Events)
                .FirstOrDefault(item => item.Id == (int)id);
        }

        protected override List<BudgetPlan> GetItems()
        {        
            return _context.BudgetPlans
                .Include(item => item.Items)
                .Include(item => item.Events)
                .ToList();
        }

        public Status GetStatusOfPlan(int planId)
        {
            if(_context.Events.Count() <= 0)
            {
                return _context.Statuses
                    .Single(status => status.Title == Constants.STATUS_BP_PROJECT);
            }
            var latestDateOfEventsCurrentBP = _context.Events
                                        .Where(ev => ev.BudgetPlanId == planId)
                                        .Max(ev => ev.Date);
            return _context.Events
                .Include(e => e.Status)
                .Single(e => e.BudgetPlanId == planId &&
                             e.Date == latestDateOfEventsCurrentBP)

                .Status;
        }
    }
}
