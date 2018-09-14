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
        ICRUD<BudgetLine> _bpItem_crud;

        public BudgetLineDAL(GetCRUD getcrud, WBSContext context)
        {
            _bpItem_crud = getcrud(typeof(BudgetLineDAL), typeof(BudgetLine)) as ICRUD<BudgetLine>;
        }

        public BudgetLine Create(BudgetLine item)
        {
            return _bpItem_crud.Create(item);
        }

        public BudgetLine Delete(object id)
        {
            return _bpItem_crud.Delete(id);
        }

        public IEnumerable<BudgetLine> Get()
        {
            return _bpItem_crud.Get();
        }

        public BudgetLine Get(object Id)
        {
            return _bpItem_crud.Get(Id);
        }

        public BudgetLine Update(BudgetLine item)
        {
            return _bpItem_crud.Update(item);
        }
    }
}
