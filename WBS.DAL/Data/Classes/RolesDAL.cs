using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Layers;
using WBS.DAL.Layers.Interfaces;

namespace WBS.DAL.Data.Classes
{
    public class RolesDAL : ICRUD<Role>
    {
        ICRUD<Role> _roles_crud;

        public RolesDAL(GetCRUD getcrud)
        {
            _roles_crud = getcrud(typeof(RolesDAL), typeof(Role)) as ICRUD<Role>;
        }

        public Role Create(Role item)
        {
            return _roles_crud.Create(item);
        }

        public Role Delete(object id)
        {
            return _roles_crud.Delete(id);
        }

        public IEnumerable<Role> Get()
        {
            return _roles_crud.Get();
        }

        public Role Get(object id)
        {
            return _roles_crud.Get(id);
        }

        public Role Update(Role item)
        {
            return _roles_crud.Update(item);
        }
    }
}
