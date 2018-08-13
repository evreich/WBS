using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Models;

namespace WBS.DAL
{
    public class TypesOfInvestmentDAL : AbstractDAL<TypeOfInvestment>
    {
        public TypesOfInvestmentDAL(WBSContext context, ICache cache) : base(context, cache) { }

        protected override IEnumerable<TypeOfInvestment> GetItems()
        {
            return _context.TypesOfInvestment.ToList();
        }

        protected override TypeOfInvestment GetItem(object id)
        {
            return _context.TypesOfInvestment.FirstOrDefault(x => x.Id == (int)id);
        }
    }
}
