using System;
using WBS.DAL.Enums;

namespace WBS.DAL.Data.Helpers
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public Object Value { get; set; }
        public FilterCondition Condition { get; set; }
    }
}
