using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class BudgetPlanViewModel : IViewModel<BudgetPlan>
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }

        public BudgetPlanViewModel() { }

        public BudgetPlanViewModel(int id, int year, string status)
        {
            Id = id;
            Year = year;
            Status = status;
        }

        public BudgetPlan CreateModel()
        {
            return new BudgetPlan {
                Id = Id,
                Year = Year
            };
        }
    }
}
