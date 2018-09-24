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
using WBS.DAL.Data.Helpers;

namespace WBS.DAL.Data.Classes
{
    public class ExtensionDALIQueryableBudgetLine : IExtensionDALIQueryable<BudgetLine>
    {
        public IQueryable<BudgetLine> GetItems(IQueryable<BudgetLine> query)
        {
            return query
                .Include(i => i.BudgetPlan)
                .Include(i => i.ResultCenter)
                .Include(i => i.CategoryOfEquipment)
                .Include(i => i.Site)
                .Include(i => i.TypeOfInvestment);
        }
    }

    public class BudgetLineDAL : ICRUD<BudgetLine>
    {
        ICRUD<BudgetLine> _budgetLine_crud;

        public BudgetLineDAL(GetCRUD getcrud, WBSContext context)
        {
            _budgetLine_crud = getcrud(typeof(BudgetLineDAL), typeof(BudgetLine)) as ICRUD<BudgetLine>;
        }

        public BudgetLine Create(BudgetLine item)
        {
            return _budgetLine_crud.Create(item);
        }

        public BudgetLine Delete(object id)
        {
            return _budgetLine_crud.Delete(id);
        }

        public IEnumerable<BudgetLine> Get()
        {
            return _budgetLine_crud.Get();
        }

        public BudgetLine Get(object Id)
        {
            return _budgetLine_crud.Get(Id);
        }

        public IEnumerable<BudgetLine> Get(List<Filter> filters, Sort sort)
        {
            return _budgetLine_crud.Get(filters, sort);
        }

        public BudgetLine Update(BudgetLine item)
        {
            return _budgetLine_crud.Update(item);
        }
    }
}
