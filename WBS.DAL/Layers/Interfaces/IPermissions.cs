using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Layers.Interfaces
{
    public interface IPermissions<T> : ICRUD<T> where T: class, IBaseEntity
    {

    }
}
