using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
 
    public class RolesViewModel: IViewModel<Role>
    {
        public RolesViewModel() {}

        public int Id { get; set; }
  
        public string Title { get; set; }

        public RolesViewModel(Role role)
        {
            if (role != null)
            {
                Id = role.Id;
                Title = role.Title;
            }
        }

        public Role CreateModel()
        {
            return new Role
            {
                Id = Id,
                Title = Title
            };
        }
    }
}
