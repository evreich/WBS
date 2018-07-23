using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class TechnicalServiceViewModel : IViewModel<TechnicalService>
    {
        public int Id { get; set; }
        public string Title { get; set; }
   

        public TechnicalServiceViewModel(TechnicalService serv)
        {
            if (serv != null)
            {
                Id = serv.Id;
                Title = serv.Title;
            }
          
        }

        public TechnicalServiceViewModel()
        {       
        }

        public TechnicalService CreateModel()
        {
            throw new NotImplementedException();
        }
    }
}
