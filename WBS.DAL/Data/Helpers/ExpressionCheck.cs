using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Helpers
{
    public class ExpressionCheck
    {
        public Delegate ExpressionDel { get; set; }

        public bool AllowRead { get; set; }
        public bool AllowWrite { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowDelete { get; set; }
    }
}
