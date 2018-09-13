using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class ObjectType : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string TypeName { get; set; }

        public string AssemblyName { get; set; }

        List<ObjectField> ObjectFields = new List<ObjectField>();
        List<RolesObjectTypes> RolesObjectTypes = new List<RolesObjectTypes>();
    }
}
