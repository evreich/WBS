using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class MenuItem : IBaseEntity
    {
        public MenuItem()
        {
            MenuItemRoles = new List<MenuItemRoles>();
            Children = new List<MenuItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string To { get; set; }

        public string IconName { get; set; }

        public string Text { get; set; }

        public MenuItem Parent { get; set; }
        public int? ParentId { get; set; }

        public List<MenuItemRoles> MenuItemRoles { get; set; }

        [NotMapped]
        public List<MenuItem> Children { get; set; }
    }
}
