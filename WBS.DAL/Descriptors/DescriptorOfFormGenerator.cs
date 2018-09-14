using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using System.Linq;
using WBS.DAL.Models;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL.Descriptors
{
    public class DescriptorOfFormGenerator
    {
        private readonly IPermissionsDAL _permissionsDAL;

        public DescriptorOfFormGenerator(IPermissionsDAL permissionsDAL)
        {
            _permissionsDAL = permissionsDAL;
        }

        private bool CanAccessToObject(string typeName, string assemblyName, List<string> roles)
        {
            return _permissionsDAL.GetPermissionsForType(typeName, assemblyName, roles).Any();
        }

        public Descriptor CreateDescriptor<T> (bool isAddingForm, List<string> roles) where T : IBaseEntity
        {
            Type typeEntity = typeof(T);
            string assemblyName = typeEntity.Assembly.GetName().Name;
            string typeName = typeEntity.FullName;

            if (!CanAccessToObject(typeName, assemblyName, roles))
            {
                throw new TypeAccessException();
            }

            List<FieldInfo> descriptorFields = new List<FieldInfo>();
            IEnumerable<RolesObjectFields> fields = _permissionsDAL.GetPermissionsForFields(typeName, assemblyName, roles);
            var distinctFields = fields.Select(f => f.ObjectField.FieldName).Distinct().ToList();

            distinctFields.ForEach(df =>
            {
                var permissions = fields.Where(f => f.ObjectField.FieldName.Equals(df)).ToList();
                bool isVisiable, canEdit;
                if (isAddingForm)
                {
                    isVisiable = permissions.Any(f => f.IsVisiableForAdd);
                    canEdit = permissions.Any(f => f.CanEditForAdd);
                }
                else
                {
                    isVisiable = permissions.Any(f => f.IsVisiableForEdit);
                    canEdit = permissions.Any(f => f.CanEditForEdit);
                }

                //TODO место для возможных проблем, т.к. просто выбираю первую строку из возможных
                var currField = permissions.First();

                descriptorFields.Add(new FieldInfo
                {
                    Name = df,
                    Label = currField.Label,
                    CanEdit = canEdit,
                    IsVisiable = isVisiable,
                    FieldComponent = currField.FieldComponent.Name
                });
            });
            return new Descriptor(descriptorFields);
        }
    }
}
