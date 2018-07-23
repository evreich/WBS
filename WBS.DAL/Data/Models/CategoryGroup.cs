using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class CategoryGroup : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        //relationships
        public List<CategoryOfEquipment> CategoriesOfEquipment { get; set; }

        public CategoryGroup()
        {
            CategoriesOfEquipment = new List<CategoryOfEquipment>();
        }

        public override string ToString()
        {
            var type = typeof(CategoryGroup);
            return type.FullName;
        }
    }
}
