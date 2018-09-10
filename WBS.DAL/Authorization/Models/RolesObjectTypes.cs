using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class RolesObjectTypes : IBaseEntity
    {
        [Key, Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ObjectTypeId { get; set; }
        public ObjectType ObjectType { get; set; }

        public bool AllowRead { get; set; }
        public bool AllowWrite { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
