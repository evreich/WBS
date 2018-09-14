using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class BudgetLine: IBaseEntity
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string SubjectOfInvestment { get; set; }
        public DateTime DateOfDelivery { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

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

        public List<RequestLine> RequestLines { get; set; }

    }
}
