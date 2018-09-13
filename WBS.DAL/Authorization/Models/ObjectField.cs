using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class ObjectField: IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FieldName { get; set; }

        public int ObjectTypeId { get; set; }
        public ObjectType ObjectType { get; set; }
    }
}
