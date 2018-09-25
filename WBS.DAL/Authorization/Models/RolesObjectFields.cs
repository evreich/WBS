using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class RolesObjectFields: IBaseEntity
    {
        [Key, Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Label { get; set; }

        public bool IsVisiableForAdd { get; set; }
        public bool CanEditForAdd { get; set; }
        public bool IsVisiableForEdit { get; set; }
        public bool CanEditForEdit { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int ObjectFieldId { get; set; }
        public ObjectField ObjectField { get; set; }

        public int FieldComponentId { get; set; }
        public FieldComponent FieldComponent { get; set; }

        public int Position { get; set; }
    }
}
