using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.DAL.Data.Classes;
using Newtonsoft.Json;

namespace WBS.DAL.Descriptors
{
    public class Descriptor
    {
        public List<FieldInfo> FormFields { get; private set; }

        public Descriptor(List<FieldInfo> fields)
        {
            FormFields = new List<FieldInfo>(fields);
        }
    }
}