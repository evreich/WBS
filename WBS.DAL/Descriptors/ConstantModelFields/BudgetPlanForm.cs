using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class BudgetPlanForm
    {
        public (string label, string name) Year { get; private set; } = ("Год", "year");

        public BudgetPlanForm()
        {
        }
    }
}
