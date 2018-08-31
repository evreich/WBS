using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;

namespace WBS.DAL.Data.Classes
{
    public class AttachmentDAL : AbstractDAL<Attachment>
    {
        public AttachmentDAL(WBSContext context, ICache cache) : base(context, cache)
        {
        }

        protected override Attachment GetItem(object id)
        {
            return _context.Attachments
                .Include(item => item.DAI)
                .FirstOrDefault(item => item.Id == (int)id);
        }

        protected override IEnumerable<Attachment> GetItems()
        {
            return _context.Attachments
                .Include(item => item.DAI)
                .ToList();
        }

    }
}
