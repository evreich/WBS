using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models
{
    //таблица Тех.службы
    public class TechnicalService : IBaseEntity
    {
        public int Id { get; set; }
       
        public string Title { get; set; }


        public override string ToString()
        {
            var type = typeof(TechnicalService);
            return type.FullName;
        }

    }
}

