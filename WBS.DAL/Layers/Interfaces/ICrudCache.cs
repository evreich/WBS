using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Interfaces;

namespace WBS.DAL.Layers.Interfaces
{
    public interface ICRUDCache<T> : ICRUD<T> where T: class, IBaseEntity
    {
    }
}
