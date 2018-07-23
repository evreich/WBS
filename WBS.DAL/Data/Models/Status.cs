using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class Status : IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //relationships
        List<Event> Events { get; set; }

        public Status()
        {
            Events = new List<Event>();
        }
    }
}
