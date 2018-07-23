using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL
{
    public interface IViewModel<T> where T: IBaseEntity
    {
        int Id { get; set; }

        T CreateModel();
    }
}
