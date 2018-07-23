using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class BudgetPlan: IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }

        //relationships
        public List<Event> Events { get; set; }
        public List<ItemOfBudgetPlan> Items { get; set; }

        public BudgetPlan()
        {
            Events = new List<Event>();
            Items = new List<ItemOfBudgetPlan>();
        }
    }
}
