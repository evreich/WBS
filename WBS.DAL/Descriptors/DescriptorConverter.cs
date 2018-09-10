using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WBS.DAL.Descriptors
{
    static class DescriptorConverter
    {
        public static string ConvertToJSON(Descriptor descriptor)
        {
            var fields = descriptor.FormFields.ToDictionary(field => field.Name);
            return JsonConvert.SerializeObject(fields);
        }
    }
}
