using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WBS.API.Descriptors
{
    internal class FieldNameAttribute: Attribute
    {
        public string Name { get; set; }

        public FieldNameAttribute()
        { }

        public FieldNameAttribute(string name)
        {
            Name = name;
        }
    }
}
