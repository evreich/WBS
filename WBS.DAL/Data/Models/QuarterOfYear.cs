using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class QuarterOfYear: IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //relationships
        public List<EventQuarter> EventQuarters { get; set; }

        public QuarterOfYear()
        {
            EventQuarters = new List<EventQuarter>();
        }
    }
}
