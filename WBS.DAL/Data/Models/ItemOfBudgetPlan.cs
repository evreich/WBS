using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class ItemOfBudgetPlan: IBaseEntity
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string ItemOfInvestment { get; set; }
        public DateTime InvestmentDate { get; set; }
        public int Count { get; set; }
        public double CostItem { get; set; }
        public double AmountAllItems { get; set; }

        //relationships
        public int BudgetPlanId { get; set; }
        public BudgetPlan BudgetPlan { get; set; }

        public int CategoryOfEquipmentId { get; set; }
        public CategoryOfEquipment CategoryOfEquipment { get; set; }

        public int? ResultCenterId { get; set; }
        public ResultCenter ResultCenter { get; set; }

        public int SiteId { get; set; }
        public Site Site { get; set; }

        public int TypeOfInvestmentId { get; set; }
        public TypeOfInvestment TypeOfInvestment { get; set; }

    }
}
