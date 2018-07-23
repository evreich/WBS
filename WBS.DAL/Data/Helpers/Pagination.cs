using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Helpers
{
    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int ElementsPerPage { get; set; }
        public int ElementsCount { get; set; }
    }
}
