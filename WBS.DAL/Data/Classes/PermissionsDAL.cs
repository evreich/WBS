using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class PermissionsDAL: IPermissionsDAL
    {
        private readonly WBSContext _context;

        public PermissionsDAL(WBSContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItem> GetPermissionsForMenuItems(List<string> roles)
        {
            var menuItems = _context.MenuItemRoles
                .Include(mir => mir.MenuItem)
                .Include(mir => mir.Role)
                .Where(mir => roles.Contains(mir.Role.Title))
                .Select(mir => mir.MenuItem);
            //генерация иерархической структуры пунктов меню
            var lookup = menuItems.ToLookup(mi => mi.ParentId);
            List<MenuItem> build(int? parentId) => lookup[parentId]
            .Select(x => new MenuItem()
            {
                Id = x.Id,
                Text = x.Text,
                To = x.To,
                IconName = x.IconName,
                Children = build(x.Id),
                ParentId = x.ParentId
            })
            .ToList();
            var resultData = build(null);
            return resultData;
        }

        public IEnumerable<RolesObjectTypes> GetPermissionsForType(string typeName, string assemblyName, List<string> roles)
        {
            return _context.RolesObjectTypes
                .Include(rot => rot.ObjectType)
                    .Include(rot => rot.Role)
                    .Where(rot => rot.ObjectType.TypeName.Equals(typeName)
                    && rot.ObjectType.AssemblyName.Equals(assemblyName)
                    && roles.Contains(rot.Role.Title));
        }
    }
}