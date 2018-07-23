﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models
{
    /// <summary>
    /// Модель DAIRequestsTechnicalServices (для реализации отношения many-to-many между таблицами DAIRequest и TechnicalService)
    /// </summary>
    public class DAIRequestsTechnicalService
    {
        public int Id { get; set; }

        public int DaiId { get; set; }
        public DAIRequest DAI { get; set; }

        public int TechnicalServId { get; set; }
        public TechnicalService TechnicalServ{ get; set; }
    }
}
