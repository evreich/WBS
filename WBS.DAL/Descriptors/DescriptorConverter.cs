using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WBS.DAL.Descriptors
{
    public static class DescriptorConverter
    {
        public static string ConvertToJSON(Descriptor descriptor)
        {
            var fields = descriptor.FormFields.ToDictionary(field => field.propName);
            return JsonConvert.SerializeObject(fields);
        }
    }
}
