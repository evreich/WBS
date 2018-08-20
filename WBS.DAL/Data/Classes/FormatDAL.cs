using System.Linq;
using System.Collections.Generic;
using WBS.DAL.Models;
using WBS.DAL.Cache;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL
{
    public class FormatDAL : AbstractDAL<Format>
    {
        public FormatDAL(WBSContext context, ICache cache) : base(context, cache) { }

        protected override IEnumerable<Format> GetItems()
        {
            return _context.Formats
                .Include(f => f.DirectorOfFormat)
                .Include(f => f.DirectorOfKYFormat)
                .Include(f => f.KYFormat)
                .ToList();
        }

        protected override Format GetItem(object id)
        {
            return _context.Formats
                .Include(f => f.DirectorOfFormat)
                .Include(f => f.DirectorOfKYFormat)
                .Include(f => f.KYFormat)
                .FirstOrDefault(f => f.Id == (int)id);
        }
    }
}
