using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Models;

namespace WBS.DAL.Descriptors
{
    public class DescriptorOfFormGenerator
    {
        private readonly IPermissionDAL _permissionsDAL;

        public DescriptorOfFormGenerator(IPermissionDAL permissionsDAL)
        {
            _permissionsDAL = permissionsDAL;
        }

        private bool CanEditField(string fieldName, object typeID, List<string> roles)
        {

            if (String.IsNullOrEmpty(fieldName))
                throw new ArgumentException("Введен пустой параметр fieldName.");
            //return _permissionsDAL.GetPermissionsForField(fieldName, typeID, roles);
            return true;
        }

        private bool CanAccessToObject(object typeID, List<string> roles)
        {
            // return _permissionsDAL.CanAccessToObject(typeID, roles);
            return true;
        }

        public Descriptor CreateDescriptor<T> (object typeID, List<string> roles) where T : IBaseEntity
        {
            if(!CanAccessToObject(typeID, roles))
            {
                throw new TypeAccessException();
            }

            Type typeEntity = typeof(T);
            switch (typeEntity)
            {
                case Type type when(typeof(CategoryGroup).Name == type.Name):
                    string name = "dsfds";
                    var fields = new List<FieldInfo>
                    {
                        new FieldInfo("sdfddfds", name, false, CanEditField(name, typeID, roles))
                    };
                        
                    return new Descriptor(fields);
                default:
                    throw new TypeAccessException();
            }
        }
    }
}
