using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Authorization.Models.ViewModels
{
    public class UserRegisterViewModel: IViewModel<User> 
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Fio { get; set; }

        public string JobPosition { get; set; }

        public string Department { get; set; }

        public bool DeletionMark { get; set; }

        public List<RolesViewModel> Roles { get; set; }

        public User CreateModel()
        {
            return new User
            {
                Id = Id,
                Login = Login,
                Password = Password,
                Fio = Fio,
                JobPosition = JobPosition,
                Department = Department,
                DeletionMark = DeletionMark
            };
        }

        public UserRegisterViewModel() { }
    }
}
