using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;

namespace WBS.DAL4.Data.Models.ViewModels
{
    public class ResultCentresForSelection
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ResultCentresForSelection(ResultCenter res)
        {
            Id = res.Id;
            Title = res.Title;
        }
    }
}
