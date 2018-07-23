using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WBS.DAL.Authorization.Models
{
    //вьюмодель для таблицы Пользователи с ролями, без паролей
    public class ProfileViewModel: IViewModel<User>
    {
        public int Id { get; set; }

        public string Fio { get; set; }

        public string JobPosition { get; set; }
  
        public string Department { get; set; }

        public bool DeletionMark { get; set; }

        public List<RolesViewModel> Roles { get; set; }

        public ProfileViewModel(User user)
        {
            Id = user.Id;
            Fio = user.Fio;
            JobPosition = user.JobPosition;
            Department = user.Department;
            DeletionMark = user.DeletionMark;
            Roles = user.UserRoles.Select(u => new RolesViewModel(u.Role)).ToList();
        }

        public ProfileViewModel()
        {
        }

        public User CreateModel()
        {
            return new User
            {
                Id = Id,
                Fio = Fio,
                JobPosition = JobPosition,
                Department = Department,
                DeletionMark = DeletionMark
            };
        }
    }
}
