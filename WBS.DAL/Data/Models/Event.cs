using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class Event: IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }

        [MaxLength(100)]
        public string Comment { get; set; }

        //relationships
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int BudgetPlanId { get; set; }
        public BudgetPlan BudgetPlan { get; set; }

        public List<EventQuarter> EventQuarters { get; set; }

        public Event()
        {
            EventQuarters = new List<EventQuarter>();
        }
    }
}
