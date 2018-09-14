using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models
{
    //таблица местоположений
    public class Site: IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //relationships
        public int? FormatId { get; set; }
        public Format Format { get; set; }

        public int? KySitId { get; set; }
        public User KySit { get; set; }

        public int? TechnicalExpertId { get; set; }
        public User TechnicalExpert { get; set; }

        public int? DirectorOfSitId { get; set; }
        public User DirectorOfSit{ get; set; }

        public int? CreaterOfBudgetId { get; set; }
        public User CreaterOfBudget { get; set; }

        public int? KyRegionId { get; set; }
        public User KyRegion { get; set; }

        public int? OperationDirectorId { get; set; }
        public User OperationDirector { get; set; }

        public List<BudgetLine> BudgetLines { get; set; }

        public Site()
        {
            
        }

        public override string ToString()
        {
            var type = typeof(Site);
            return type.FullName;
        }

    }
}

