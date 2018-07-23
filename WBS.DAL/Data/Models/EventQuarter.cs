using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models
{
    public class EventQuarter
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int QuarterOfYearId { get; set; }
        public QuarterOfYear QuarterOfYear { get; set; }
    }
}
