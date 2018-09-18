using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.DAL.Descriptors
{
    public struct FieldInfo
    {
        public string label { get; set; }
        public string propName { get; set; }
        public bool isVisible { get; set; }
        public bool canEdit { get; set; }
        public string fieldComponent { get; set; }
        //TODO: add validation prop

        public FieldInfo(string label, string name, bool isVisible, bool canEdit, string fieldComponent)
        {
            this.label = label;
            this.propName = name;
            this.isVisible = isVisible;
            this.canEdit = canEdit;
            this.fieldComponent = fieldComponent;
        }
    }
}