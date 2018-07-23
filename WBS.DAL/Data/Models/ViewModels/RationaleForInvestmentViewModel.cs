using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class RationaleForInvestmentViewModel : IViewModel<RationaleForInvestment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
   

        public RationaleForInvestmentViewModel(RationaleForInvestment item)
        {
            if (item != null)
            {
                Id = item.Id;
                Title = item.Title;
            }
          
        }

        public RationaleForInvestmentViewModel()
        {       
        }

        public RationaleForInvestment CreateModel()
        {
            throw new NotImplementedException();
        }
    }
}
