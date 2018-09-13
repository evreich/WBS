using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Descriptors
{
    public struct FieldInfo
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public bool IsVisiable { get; set; }
        public bool CanEdit { get; set; }
        public string FieldComponent { get; set; }
        //TODO: add validation prop

        public FieldInfo(string label, string name, bool isVisiable, bool canEdit, string fieldComponent)
        {
            Label = label;
            Name = name;
            IsVisiable = isVisiable;
            CanEdit = canEdit;
            FieldComponent = fieldComponent;
        }
    }
}