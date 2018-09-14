using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Authorization.Models.ViewModels
{
    public class TokenViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public string Roles { get; set; }
        public List<MenuItem> AvailableMenuItems { get; set; }
    }
}
