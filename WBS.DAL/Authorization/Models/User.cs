using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User : IBaseEntity
    {
        [Key, Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("fio")]
        public string Fio { get; set; }

        [Column("jobPosition")]
        public string JobPosition { get; set; }

        [Column("department")]
        public string Department { get; set; }

        [Column("deletionMark")]
        public bool DeletionMark { get; set; }


        /// <summary>
        ///for relation many-to-many with Roles
        /// </summary>
        public List<UserRoles> UserRoles { get; set; }

        public User()
        {
            UserRoles = new List<UserRoles>();
        }
       
    }
}
