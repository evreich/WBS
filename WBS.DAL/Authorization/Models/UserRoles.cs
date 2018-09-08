using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
 {  /// <summary>
    /// Модель UserRoles (для реализации отношения many-to-many между таблицами User и Roles)
    /// </summary>
    public class UserRoles : IBaseEntity
    {
        public UserRoles()
        {
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
