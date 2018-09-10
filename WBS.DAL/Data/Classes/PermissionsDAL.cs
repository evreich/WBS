using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Classes
{
    public interface IPermissionDAL
    {
        List<object> GetPermissionsForType(string typeName, List<string> roles);
        List<object> GetPermissionsForField(string fieldName, string typeName, List<string> roles);
    }

    public class PermissionsDAL: IPermissionDAL
    {
        private readonly WBSContext _context;

        public PermissionsDAL(WBSContext context)
        {
            _context = context;
        }

        public List<object> GetPermissionsForType(string typeName, List<string> roles)
        {
            /*
             * return _context.PermisssionsToType
                .Include(p => p.Role)
                .Include(p => p.Type)
                .Where(p => p.Type.Name == typeName && roles.Contains(p.Role.Name))
                .ToList();

            */
            return null;
        }

        public List<object> GetPermissionsForField(string fieldName, string typeName, List<string> roles)
        {
            /*
             * return _context.PremissionsToTypeField
                .Include(p => p.Role)
                .Include(p => p.Field)
                    .ThenInclude(f => f.Type)
                .Where(p => p.Field.Type.Name == typeName && 
                            p.Field.Name == fieldName &&
                            roles.Contains(p.Role.Name))
                .ToList();

            */
            return null;
        } 
    }
}
