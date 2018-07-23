using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    /// <summary>
    /// Модель ролей
    /// </summary>
    public class Role : IBaseEntity
    {
        [Key, Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        /// <summary>
        /// deprecated routes for role
        /// </summary>
        [Column("routes")]
        public string Routes { get; set; }
        public List<UserRoles> UserRoles { get; set; }
    }
}
