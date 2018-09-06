using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.API.Descriptors
{
    internal struct FieldAttributes
    {
        public string Label { get; set; }
        public string Name { get; set; }
        public bool IsVisiable { get; set; }
        public bool CanEdit { get; set; }

        public FieldAttributes(string label, string name, bool isVisiable, bool canEdit)
        {
            Label = label;
            Name = name;
            IsVisiable = isVisiable;
            CanEdit = canEdit;
        }
    }
}
