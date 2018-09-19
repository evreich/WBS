using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Enums;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class BudgetLineViewModel : IViewModel<BudgetLine>
    {
        public int Id { get; set; }

        public string SubjectOfInvestment { get; set; }
        public Month PlannedInvestmentDate { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }

        //relationships
        public int BudgetPlanId { get; set; }
        public string BudgetPlan { get; set; }

        public int CategoryOfEquipmentId { get; set; }
        public string CategoryOfEquipment { get; set; }

        public int? ResultCenterId { get; set; }
        public string ResultCenter { get; set; }

        public int SiteId { get; set; }
        public string Site { get; set; }

        public int TypeOfInvestmentId { get; set; }
        public string TypeOfInvestment { get; set; }

        public BudgetLineViewModel()
        {
        }

        public BudgetLineViewModel(BudgetLine item)
        {
            Id = item.Id;
            SubjectOfInvestment = item.SubjectOfInvestment;
            PlannedInvestmentDate = item.PlannedInvestmentDate;
            Count = item.Count;
            Price = item.Price;
            Amount = item.Amount;

            BudgetPlanId = item.BudgetPlanId;
            if (item.BudgetPlan != null) BudgetPlan = item.BudgetPlan.Year.ToString();

            CategoryOfEquipmentId = item.CategoryOfEquipmentId;
            if (item.CategoryOfEquipment != null)  CategoryOfEquipment = item.CategoryOfEquipment.Title;

            ResultCenterId = item.ResultCenterId;
            if (item.ResultCenter != null)  ResultCenter = item.ResultCenter.Title;

            SiteId = item.SiteId;
            if (item.Site != null)  Site = item.Site.Title;

            TypeOfInvestmentId = item.TypeOfInvestmentId;
            if (item.TypeOfInvestment != null)  TypeOfInvestment = item.TypeOfInvestment.Title;
        }

        public BudgetLine CreateModel()
        {
            return new BudgetLine()
            {
                Id = this.Id,
                SubjectOfInvestment = this.SubjectOfInvestment,
                PlannedInvestmentDate = this.PlannedInvestmentDate,
                Count = this.Count,
                Price = this.Price,
                Amount = this.Amount,

                BudgetPlanId = this.BudgetPlanId,
                CategoryOfEquipmentId = this.CategoryOfEquipmentId,
                ResultCenterId = this.ResultCenterId,
                SiteId = this.SiteId,
                TypeOfInvestmentId = this.TypeOfInvestmentId
            };  
        }
    }
}
