using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Layers;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class RoleObjectTypesDAL : ICRUD<RolesObjectTypes>
    {
        ICRUD<RolesObjectTypes> _roles_object_types;

        public RoleObjectTypesDAL(GetCRUD getcrud)
        {
            _roles_object_types = getcrud(typeof(RoleObjectTypesDAL), typeof(RolesObjectTypes)) as ICRUD<RolesObjectTypes>;
        }

        public RolesObjectTypes Create(RolesObjectTypes item)
        {
            return _roles_object_types.Create(item);
        }

        public RolesObjectTypes Delete(object id)
        {
            return _roles_object_types.Delete(id);
        }

        public IEnumerable<RolesObjectTypes> Get()
        {
            return _roles_object_types.Get();
        }

        public RolesObjectTypes Get(object id)
        {
            return _roles_object_types.Get(id);
        }

        public RolesObjectTypes Update(RolesObjectTypes item)
        {
            return _roles_object_types.Update(item);
        }
    }
}
