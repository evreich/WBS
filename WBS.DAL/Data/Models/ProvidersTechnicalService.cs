using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    /// <summary>
    /// Модель ProvidersTechnicalServices (для реализации отношения many-to-many между таблицами Provider и TechnicalService)
    /// </summary>
    public class ProvidersTechnicalService: IBaseEntity
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public int TechnicalServiceId { get; set; }
        public TechnicalService TechnicalService { get; set; }
    }
}
