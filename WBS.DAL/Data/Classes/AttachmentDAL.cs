using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using WBS.DAL.Layers;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class ExtensionDALIQueryableAttachment : IExtensionDALIQueryable<Attachment>
    {
        public IQueryable<Attachment> GetItems(IQueryable<Attachment> query)
        {
            return query.Include(b => b.DAI);
        }

    }
    public class AttachmentDAL : ICRUD<Attachment>
    {
        ICRUD<Attachment> _attachments_crud;

        public AttachmentDAL(GetCRUD getcrud)
        {
            _attachments_crud = getcrud(typeof(AttachmentDAL), typeof(Attachment)) as ICRUD<Attachment>;
        }

        public Attachment Create(Attachment item)
        {
            return _attachments_crud.Create(item);
        }

        public Attachment Delete(object id)
        {
            return _attachments_crud.Delete(id);
        }

        public IEnumerable<Attachment> Get()
        {
            return _attachments_crud.Get();
        }

        public Attachment Get(object id)
        {
            return _attachments_crud.Get(id);
        }

        public IEnumerable<Attachment> Get(List<Filter> filters, Sort sort)
        {
            return _attachments_crud.Get(filters, sort);
        }

        public Attachment Update(Attachment item)
        {
            return _attachments_crud.Update(item);
        }
    }
}
