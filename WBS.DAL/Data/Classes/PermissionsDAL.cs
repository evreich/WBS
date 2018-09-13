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

        public IEnumerable<RolesObjectTypes> GetPermissionsForType(string typeName, string assemblyName, List<string> roles)
        {
            return _context.RolesObjectTypes
                .Include(rot => rot.ObjectType)
                    .Include(rot => rot.Role)
                    .Where(rot => rot.ObjectType.TypeName.Equals(typeName)
                    && rot.ObjectType.AssemblyName.Equals(assemblyName)
                    && roles.Contains(rot.Role.Title));
        }

        public IEnumerable<RolesObjectFields> GetPermissionsForFields(string typeName, string assemblyName, List<string> roles)
        {
            return _context.RolesObjectFields
                .Include(rof => rof.FieldComponent)
                .Include(rof => rof.Role)
                .Include(rof => rof.ObjectField)
                    .ThenInclude(f => f.ObjectType)
                .Where(rof => rof.ObjectField.ObjectType.AssemblyName.Equals(assemblyName)
                    && rof.ObjectField.ObjectType.TypeName.Equals(typeName)
                    && roles.Contains(rof.Role.Title));
        }
    }
}