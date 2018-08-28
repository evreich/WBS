using System;
using WBS.API.Enums;

namespace WBS.API.Helpers
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public Object Value { get; set; }
        public FilterCondition Condition { get; set; }
    }
}
