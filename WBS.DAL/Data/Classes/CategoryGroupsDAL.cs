using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;
using System;

namespace WBS.DAL
{
    public class CategoryGroupsDAL : AbstractDAL<CategoryGroup>
    {
        public CategoryGroupsDAL(WBSContext context, ICache cache) : base(context, cache)
        { }

        protected override List<CategoryGroup> GetItems()
        {
            return _context.CategoryGroups.ToList();
        }

        protected override CategoryGroup GetItem(object id)
        {
            return _context.CategoryGroups.FirstOrDefault(x => x.Id == (int)id);
        }
    }
}
