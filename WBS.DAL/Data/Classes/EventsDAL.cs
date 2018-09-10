using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL.Data.Classes
{
    public class ExtensionDALIQueryableEvent : IExtensionDALIQueryable<Event>
    {
        public IQueryable<Event> GetItems(IQueryable<Event> query)
        {
            return query.Include(item => item.BudgetPlan)
                .Include(item => item.Status)
                .Include(item => item.EventQuarters)
                    .ThenInclude(items => items.QuarterOfYear);
        }
    }

    public class EventsDAL : ICRUD<Event>
    {
        ICRUD<Event> _events_crud;

        public EventsDAL(GetCRUD getcrud)
        {
            _events_crud = getcrud(typeof(EventsDAL), typeof(Event)) as ICRUD<Event>;
        }

        public Event Create(Event item)
        {
            return _events_crud.Create(item);
        }

        public Event Delete(object id)
        {
            return _events_crud.Delete(id);
        }

        public IEnumerable<Event> Get()
        {
            return _events_crud.Get();
        }

        public Event Get(object id)
        {
            return _events_crud.Get(id);
        }

        public Event Update(Event item)
        {
            return _events_crud.Update(item);
        }
    }
}
