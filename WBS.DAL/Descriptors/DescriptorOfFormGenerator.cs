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
using WBS.DAL.Enums;

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

        public Descriptor CreateDescriptor<T> (TypeOfDescriptor typeOfDescriptor, List<string> roles) where T : IBaseEntity
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
                //TODO место для возможных проблем, т.к. просто выбираю первую строку из возможных
                var currField = permissions.First();

                bool isVisiable, canEdit;
                string fieldComponent = String.Empty;
                switch (typeOfDescriptor)
                {
                    case TypeOfDescriptor.AddingForm:
                        isVisiable = permissions.Any(f => f.IsVisiableForAdd);
                        canEdit = permissions.Any(f => f.CanEditForAdd);
                        break;
                    case TypeOfDescriptor.EditForm:
                        isVisiable = permissions.Any(f => f.IsVisiableForEdit);
                        canEdit = permissions.Any(f => f.CanEditForEdit);
                        break;
                    case TypeOfDescriptor.ReadForm:
                        isVisiable = true;
                        canEdit = false;
                        fieldComponent = "TextFieldPlaceholder";
                        break;
                    default:
                        isVisiable = false;
                        canEdit = false;
                        break;
                }

                descriptorFields.Add(new FieldInfo
                {
                    propName = df,
                    label = currField.Label,
                    canEdit = canEdit,
                    isVisible = isVisiable,
                    fieldComponent = String.IsNullOrEmpty(fieldComponent) ? currField.FieldComponent.Name : fieldComponent
                });
            });
            return new Descriptor(descriptorFields);
        }
    }
}
