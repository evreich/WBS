using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;
using WBS.DAL.Data.Helpers;

namespace WBS.DAL.Data.Classes
{
    public class ExtensionDALIQueryableBudgetPlan : IExtensionDALIQueryable<BudgetPlan>
    {
        public IQueryable<BudgetPlan> GetItems(IQueryable<BudgetPlan> query)
        {
            return query.Include(b => b.Items).Include(b => b.Events);
        }
    }

    public class BudgetPlanDAL: ICRUD<BudgetPlan>
    {
        ICRUD<BudgetPlan> _bp_crud;
        ICRUD<Event> _events_crud;
        ICRUD<Status> _statuses_crud;

        public BudgetPlanDAL(GetCRUD getcrud, WBSContext ctx)
        {
            _bp_crud = getcrud(typeof(BudgetPlanDAL), typeof(BudgetPlan)) as ICRUD<BudgetPlan>;
            _events_crud = getcrud(typeof(BudgetPlanDAL), typeof(Event)) as ICRUD<Event>;
            _statuses_crud = getcrud(typeof(BudgetPlanDAL), typeof(Status)) as ICRUD<Status>;
        }

        public bool IsAlreadyHaveInDb(int year)
        {
            return _bp_crud.Get().Any(bp => bp.Year == year);
        }

        public Status GetStatusOfPlan(int planId)
        {
            if(_events_crud.Get().Count() <= 0)
            {
                return _statuses_crud.Get()
                    .Single(status => status.Title == Constants.STATUS_BP_PROJECT);
            }
            var events = _events_crud.Get();
            var latestDateOfEventsCurrentBP = events
                                        .Where(ev => ev.BudgetPlanId == planId)
                                        ?.Max(ev => ev.Date);

            return _events_crud.Get().AsQueryable()
                .Include(e => e.Status)
                .Single(e => e.BudgetPlanId == planId &&
                             e.Date == latestDateOfEventsCurrentBP)

                .Status;
        }

        public BudgetPlan Update(BudgetPlan item)
        {
            return _bp_crud.Update(item);
        }

        public BudgetPlan Delete(object id)
        {
            return _bp_crud.Delete(id);
        }

        public BudgetPlan Create(BudgetPlan item)
        {
            return _bp_crud.Create(item);
        }

        public IEnumerable<BudgetPlan> Get()
        {
            return _bp_crud.Get();
        }

        public BudgetPlan Get(object Id)
        {
            return _bp_crud.Get(Id);
        }

        public IEnumerable<BudgetPlan> Get(List<Filter> filters, Sort sort)
        {
            return _bp_crud.Get(filters, sort);
        }
    }
}
