using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL4.Data.Models.ViewModels
{
    //облегченная вьюмодель Пользователей 
    public class ProfilesForSelection
    {
        public int Id { get; set; }        
        public string Login { get; set; }
        public string Fio { get; set; }

        public ProfilesForSelection(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Fio = user.Fio;
        }
    }
}
