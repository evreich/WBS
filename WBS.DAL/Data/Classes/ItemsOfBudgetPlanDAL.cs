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
    public class ExtensionDALIQueryableItemOfBudgetPlan : IExtensionDALIQueryable<ItemOfBudgetPlan>
    {
        public IQueryable<ItemOfBudgetPlan> GetItems(IQueryable<ItemOfBudgetPlan> query)
        {
            return query
                .Include(i => i.BudgetPlan)
                .Include(i => i.ResultCenter)
                .Include(i => i.CategoryOfEquipment)
                .Include(i => i.Site)
                .Include(i => i.TypeOfInvestment);
        }
    }

    public class ItemsOfBudgetPlanDAL : ICRUD<ItemOfBudgetPlan>
    {
        ICRUD<ItemOfBudgetPlan> _bpItem_crud;

        public ItemsOfBudgetPlanDAL(GetCRUD getcrud, WBSContext context)
        {
            _bpItem_crud = getcrud(typeof(ItemsOfBudgetPlanDAL), typeof(ItemOfBudgetPlan)) as ICRUD<ItemOfBudgetPlan>;
        }

        public ItemOfBudgetPlan Create(ItemOfBudgetPlan item)
        {
            return _bpItem_crud.Create(item);
        }

        public ItemOfBudgetPlan Delete(object id)
        {
            return _bpItem_crud.Delete(id);
        }

        public IEnumerable<ItemOfBudgetPlan> Get()
        {
            return _bpItem_crud.Get();
        }

        public ItemOfBudgetPlan Get(object Id)
        {
            return _bpItem_crud.Get(Id);
        }

        public ItemOfBudgetPlan Update(ItemOfBudgetPlan item)
        {
            return _bpItem_crud.Update(item);
        }
    }
}
