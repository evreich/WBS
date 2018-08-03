using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class InvestmentRationaleForSelection
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public InvestmentRationaleForSelection(RationaleForInvestment item)
        {
            Id = item.Id;
            Title = item.Title;
        }
    }
}
