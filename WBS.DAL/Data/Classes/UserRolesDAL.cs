using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Layers;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class UserRolesDAL : ICRUD<UserRoles>
    {
        ICRUD<UserRoles> _user_roles_crud;

        public UserRolesDAL(GetCRUD getcrud)
        {
            _user_roles_crud = getcrud(typeof(UserRolesDAL), typeof(UserRoles)) as ICRUD<UserRoles>;
        }

        public UserRoles Create(UserRoles item)
        {
            return _user_roles_crud.Create(item);
        }

        public UserRoles Delete(object id)
        {
            return _user_roles_crud.Delete(id);
        }

        public IEnumerable<UserRoles> Get()
        {
            return _user_roles_crud.Get();
        }

        public UserRoles Get(object id)
        {
            return _user_roles_crud.Get(id);
        }

        public UserRoles Update(UserRoles item)
        {
            return _user_roles_crud.Update(item);
        }
    }
}
