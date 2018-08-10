using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WBS.DAL.Data.Classes
{
    public class ItemsOfBudgetPlanDAL : AbstractDAL<ItemOfBudgetPlan>
    {
        public ItemsOfBudgetPlanDAL(WBSContext context, ICache cache) : base(context, cache)
        {
        }

        protected override ItemOfBudgetPlan GetItem(object id)
        {
            return _context.ItemOfBudgetPlans
                .Include(item => item.BudgetPlan)
                .Include(item => item.ResultCenter)
                .Include(item => item.CategoryOfEquipment)
                .Include(item => item.Site)
                .Include(item => item.TypeOfInvestment)
                .FirstOrDefault(item => item.Id == (int)id);
        }

        protected override List<ItemOfBudgetPlan> GetItems()
        {
            return _context.ItemOfBudgetPlans
                .Include(item => item.BudgetPlan)
                .Include(item => item.ResultCenter)
                .Include(item => item.CategoryOfEquipment)
                .Include(item => item.Site)
                .Include(item => item.TypeOfInvestment)
                .ToList();
        }
    }
}
