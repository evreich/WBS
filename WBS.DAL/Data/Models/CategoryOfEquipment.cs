using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class CategoryOfEquipment : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public double DepreciationPeriod { get; set; }

        //relationships
        public int? CategoryGroupId { get; set; }
        public CategoryGroup CategoryGroup { get; set; }

        public List<ItemOfBudgetPlan> ItemsOfBudgetPlan { get; set; }

        public override string ToString()
        {
            var type = typeof(CategoryOfEquipment);
            return type.FullName;
        }
    }
}
