using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Descriptors.ConstantModelFields
{
    public class DAIRequestForm
    {
        public (string label, string name) CreationData { get; private set; }
        public (string label, string name) Site { get; private set; }
        public (string label, string name) LastModifiedDate { get; private set; }
        public (string label, string name) Subject { get; private set; }
        public (string label, string name) Number { get; private set; }
        public (string label, string name) DirectorApprovalDate { get; private set; }
        public (string label, string name) ResultCenter { get; private set; }
        public (string label, string name) DeliveryTime { get; private set; }
        public (string label, string name) ApprovalOfTechExpertIsRequired { get; private set; }
        public (string label, string name) RationaleForInvestment { get; private set; }
        public (string label, string name) CommentForDirectorGeneral { get; private set; }
        public (string label, string name) ReasonForDAI { get; private set; }
        public (string label, string name) TotalInvestment { get; private set; }
        public (string label, string name) EstimatedOperationPeriod { get; private set; }
        public (string label, string name) AdditionalSalesPerYear { get; private set; }
        public (string label, string name) SavingsPerYear { get; private set; }
        public (string label, string name) PeriodOfPayback { get; private set; }
        public (string label, string name) NetMargin { get; private set; }
        public (string label, string name) InternalRateOfReturn { get; private set; }
        public (string label, string name) NetPresentValue { get; private set; }
        public (string label, string name) MarginOnAddedValue { get; private set; }
        public (string label, string name) ExtraAnnualCost { get; private set; }
        public (string label, string name) TechnicalServices { get; private set; }

        public DAIRequestForm()
        {
            CreationData = ("Дата создания", "creationData");
            Site = ("Название сита", "site");
            LastModifiedDate = ("Дата последней модификации", "lastModifiedDate");
            Subject = ("Предмет инвестиции", "subject");
            Number = ("Номер заявки","number");
            DirectorApprovalDate = ("Дата утверждения директором", "directorApprovalDate");
            ResultCenter = ("Центр результата", "resultCenter");
            DeliveryTime = ("Желаемый срок поставки", "deliveryTime");
            ApprovalOfTechExpertIsRequired = ("Требуется одобрение технического эксперта", "approvalOfTechExpertIsRequired");
            RationaleForInvestment = ("Обоснование необходимости инвестиций", "rationaleForInvestment");
            CommentForDirectorGeneral = ("Комментарий для генерального директора", "commentForDirectorGeneral");
            ReasonForDAI = ("Причины заполнения заявки", "reasonForDAI");
            TotalInvestment = ("Всего инвестиций", "totalInvestment");
            EstimatedOperationPeriod = ("Предположительный срок эксплуатации", "estimatedOperationPeriod");
            AdditionalSalesPerYear = ("Дополнительные продажи за год", "additionalSalesPerYear");
            SavingsPerYear = ("Экономия средств в год", "savingsPerYear");
            PeriodOfPayback = ("Срок окупаемости", "periodOfPayback");
            NetMargin = ("Чистая маржа %", "netMargin");
            InternalRateOfReturn = ("Внутренняя ставка доходности", "internalRateOfReturn");
            NetPresentValue = ("Чистая приведенная стоимость", "netPresentValue");
            MarginOnAddedValue = ("Маржа на добавочную стоимость", "marginOnAddedValue");
            ExtraAnnualCost = ("Дополнительные ежегодные затраты", "extraAnnualCost");
            TechnicalServices = ("Выбор технической службы*", "technicalServices");
        }
    }
}
