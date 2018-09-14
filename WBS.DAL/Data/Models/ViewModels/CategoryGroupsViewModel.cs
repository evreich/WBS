using System;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class CategoryGroupsViewModel : IViewModel<CategoryGroup>
    {
        public CategoryGroupsViewModel()
        {
        }

        public CategoryGroupsViewModel(CategoryGroup categoryGroups)
        {
            Id = categoryGroups.Id;
            Title = categoryGroups.Title;
            Code = categoryGroups.Code;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public CategoryGroup CreateModel()
        {
            return new CategoryGroup
            {
                Id = Id,
                Title = Title,
                Code = Code,
            };
        }
    }
}
