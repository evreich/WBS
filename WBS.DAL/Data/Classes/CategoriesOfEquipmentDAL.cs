using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class CategoriesOfEquipmentDAL : AbstractDAL<CategoryOfEquipment>
    {
        public CategoriesOfEquipmentDAL(WBSContext context, ICache cache): base(context, cache)
        {
        }

        protected override IEnumerable<CategoryOfEquipment> GetItems()
        {
            return _context.CategoriesOfEquipment.Include(f => f.CategoryGroup).ToList();
        }

        protected override CategoryOfEquipment GetItem(object id)
        {
            return _context.CategoriesOfEquipment
                .Include(f => f.CategoryGroup)
                .FirstOrDefault(x => x.Id == (int)id);
        }
    }
}
