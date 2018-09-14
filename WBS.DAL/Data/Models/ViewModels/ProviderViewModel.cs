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
        public List<int> Profiles { get; set; }
        public string ProfilesString { get; set; }

        public ProviderViewModel(Provider provider)
        {
            if (provider != null)
            {
                Id = provider.Id;
                Title = provider.Title;

                if (provider.ProvidersTechnicalServices != null)
                {
                    Profiles = provider.ProvidersTechnicalServices.Select(p => p.TechnicalService.Id).ToList();

                    var profilesTitles = provider.ProvidersTechnicalServices.Select(p => p.TechnicalService.Title).ToList();
                    ProfilesString = String.Join(", ", profilesTitles);
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
                ProvidersTechnicalServices = Profiles.Select(profileId => new ProvidersTechnicalService(Id, profileId)).ToList()
            };
        }
    }
}