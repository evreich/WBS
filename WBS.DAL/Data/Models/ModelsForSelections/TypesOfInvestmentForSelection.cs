using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ModelsForSelections
{
    class TypesOfInvestmentForSelection
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public TypesOfInvestmentForSelection(TypeOfInvestment typeOfInvestment)
        {
            Id = typeOfInvestment.Id;
            Title = typeOfInvestment.Title;
        }
    }
}
