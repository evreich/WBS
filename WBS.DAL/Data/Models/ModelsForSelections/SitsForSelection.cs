using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
namespace WBS.DAL.Data.Models.ViewModels
{
    public class SitsForSelection
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SitsForSelection(Site sit)
        {
            Id = sit.Id;
            Title = sit.Title;
        }
    }
}
