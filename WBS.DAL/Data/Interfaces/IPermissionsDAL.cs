using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL.Data.Interfaces
{
    public interface IPermissionsDAL
    {
        IEnumerable<RolesObjectTypes> GetPermissionsForType(string typeName, string assemblyName, List<string> roles);
        //IEnumerable<RolesObjectTypes> GetPermissionsForField(string fieldName, string typeName, string assemblyName, List<string> roles);
    }
}
