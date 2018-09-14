using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class TypeOfInvestment: IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string ExternalCode { get; set; }

        //relationships
        public List<BudgetLine> BudgetLines { get; set; }

        public override string ToString()
        {
            var type = typeof(TypeOfInvestment);
            return type.FullName;
        }
    }
}
