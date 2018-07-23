using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models
{
    //таблица Заявки
    public class DAIRequest : IBaseEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
       
        public DateTime? CreationData { get; set; }

        public DateTime? LastModifiedData { get; set; }

        public DateTime? ReceiptTaskData { get; set; }

        public DateTime? DirectorApprovalDate { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public string Subject { get; set; }

        public bool ApprovalOfTechExpertIsRequired { get; set; }

        public int? RationaleForInvestmentId { get; set; }
        public RationaleForInvestment RationaleForInvestment { get; set; }

        public int? SitId { get; set; }
        public Site Sit { get; set; }

        //Комментарий для генерального директора
        public string CommentForDirectorGeneral { get; set; }

        public int? ResultCentreId { get; set; }
        public ResultCenter ResultCentre { get; set; }

        //Всего инвестиций
        public double TotalInvestment { get; set; }
        //Предположительный срок эксплуатации
        public double EstimatedOperationPeriod { get; set; }
        //Дополнительные продажи за год
        public double AdditionalSalesPerYear { get; set; }
        //Маржа на добавачную стоимость
        public double MarginOnAddedValue { get; set; }
        //Срок окупаемости
        public double PeriodOfPayback { get; set; }
        //Дополнительные ежегодные затраты
        public double ExtraAnnualCost { get; set; }
        //Чистая маржа
        public double NetMargin { get; set; }
        //Внутренняя ставка доходности
        public double InternalRateOfReturn { get; set; }
        //Чистая приведенная стоимость
        public double NetPresentValue { get; set; }
        //Экономия средств в год
        public double SavingsPerYear { get; set; }
        
        //Причина заявки на инвестиции
        public string ReasonForDAI { get; set; }



        public List<DAIRequestsTechnicalService> DAIRequestsTechnicalService { get; set; }
        public List<DAIRequestsProvider> DAIRequestsProviders { get; set; }
        

        public override string ToString()
        {
            var type = typeof(DAIRequest);
            return type.FullName;
        }

    }
}

