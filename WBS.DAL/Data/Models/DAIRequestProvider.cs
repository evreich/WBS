using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models
{
    /// <summary>
    /// Модель DAIRequestsProvider (для реализации отношения many-to-many между таблицами DAIRequest и Provider)
    /// </summary>
    public class DAIRequestsProvider
    {
        public int Id { get; set; }

        public int DaiId { get; set; }
        public DAIRequest DAI { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
