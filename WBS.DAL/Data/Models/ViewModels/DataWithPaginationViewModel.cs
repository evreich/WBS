using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class DataWithPaginationViewModel<T>
    {
        public IEnumerable <T> Data { get; set; }
        public Pagination Pagination { get; set; }
    }
}
