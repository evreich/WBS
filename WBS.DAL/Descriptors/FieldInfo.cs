using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Descriptors
{
    internal struct FieldInfo
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public bool IsVisiable { get; set; }
        public bool CanEdit { get; set; }

        public FieldInfo(string label, string name, bool isVisiable, bool canEdit)
        {
            Label = label;
            Name = name;
            IsVisiable = isVisiable;
            CanEdit = canEdit;
        }
    }
}