using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class ItemOfBudgetPlanViewModel : IViewModel<ItemOfBudgetPlan>
    {
        public int Id { get; set; }

        public string ItemOfInvestment { get; set; }
        public DateTime InvestmentDate { get; set; }
        public int Count { get; set; }
        public double CostItem { get; set; }
        public double AmountAllItems { get; set; }

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

        public ItemOfBudgetPlanViewModel()
        {
        }

        public ItemOfBudgetPlanViewModel(ItemOfBudgetPlan item)
        {
            Id = item.Id;
            ItemOfInvestment = item.ItemOfInvestment;
            InvestmentDate = item.InvestmentDate;
            Count = item.Count;
            CostItem = item.CostItem;
            AmountAllItems = item.AmountAllItems;

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

        public ItemOfBudgetPlan CreateModel()
        {
            return new ItemOfBudgetPlan()
            {
                Id = this.Id,
                ItemOfInvestment = this.ItemOfInvestment,
                InvestmentDate = this.InvestmentDate,
                Count = this.Count,
                CostItem = this.CostItem,
                AmountAllItems = this.AmountAllItems,

                BudgetPlanId = this.BudgetPlanId,
                CategoryOfEquipmentId = this.CategoryOfEquipmentId,
                ResultCenterId = this.ResultCenterId,
                SiteId = this.SiteId,
                TypeOfInvestmentId = this.TypeOfInvestmentId
            };  
        }
    }
}
