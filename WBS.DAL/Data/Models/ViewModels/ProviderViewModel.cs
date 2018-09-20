using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class ProviderViewModel : IViewModel<Provider>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TechnicalServiceViewModel> ProvidersTechnicalServices { get; set; }

        public ProviderViewModel(Provider provider)
        {
            if (provider != null)
            {
                Id = provider.Id;
                Title = provider.Title;

                if (provider.ProvidersTechnicalServices != null)
                {
                    ProvidersTechnicalServices = provider.ProvidersTechnicalServices.Select(p => new TechnicalServiceViewModel(p.TechnicalService)).ToList();
                }
            }
        }

        public ProviderViewModel()
        {
        }

        public Provider CreateModel()
        {
            return new Provider
            {
                Id = Id,
                Title = Title,
                ProvidersTechnicalServices = ProvidersTechnicalServices.Select(elem => new ProvidersTechnicalService(Id, elem.Id)).ToList()
            };
        }
    }
}
