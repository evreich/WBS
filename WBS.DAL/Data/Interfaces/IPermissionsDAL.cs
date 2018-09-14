using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL.Data.Interfaces
{
    public interface IPermissionsDAL
    {
        IEnumerable<RolesObjectTypes> GetPermissionsForType(string typeName, string assemblyName, List<string> roles);
        IEnumerable<MenuItem> GetPermissionsForMenuItems(List<string> roles);
        IEnumerable<RolesObjectFields> GetPermissionsForFields(string typeName, string assemblyName, List<string> roles);
    }
}
