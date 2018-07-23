using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models
{
    //таблица Обоснование необходимости инвестиций
    public class RationaleForInvestment : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            var type = typeof(RationaleForInvestment);
            return type.FullName;
        }

    }
}

