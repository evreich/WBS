using System;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class DAIRequestViewModel : IViewModel<DAIRequest>, IBaseEntity
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string CreationData { get; set; }

        public string LastModifiedData { get; set; }

        public DateTime? ReceiptTaskData { get; set; }

        public DateTime? DirectorApprovalDate { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public string Subject { get; set; }

        public int? SiteId { get; set; }
        public string SiteName { get; set; }

        public int? ResultCentreId { get; set; }
        public string ResultCentreTitle { get; set; }

        public string CommentForDirectorGeneral { get; set; }

        public bool ApprovalOfTechExpertIsRequired { get; set; }

        public int? RationaleForInvestmentId { get; set; }
        public string RationaleForInvestmentTitle { get; set; }

        public double TotalInvestment { get; set; }
        public double EstimatedOperationPeriod { get; set; }
        public double AdditionalSalesPerYear { get; set; }
        public double MarginOnAddedValue { get; set; }
        public double PeriodOfPayback { get; set; }
        public double ExtraAnnualCost { get; set; }
        public double NetMargin { get; set; }
        public double InternalRateOfReturn { get; set; }
        public double NetPresentValue { get; set; }
        public double SavingsPerYear { get; set; }

        public string ReasonForDAI { get; set; }

        public List<ProviderViewModel> Providers { get; set; }
        public List<TechnicalServiceViewModel> TechnicalServices { get; set; }

        public DAIRequestViewModel(DAIRequest request)
        {
            Id = request.Id;
            CreationData = request.CreationData.Value.ToString("dd-MM-yyyy");
            LastModifiedData = request.LastModifiedData.Value.ToString("dd-MM-yyyy");
            ReceiptTaskData = request.ReceiptTaskData;
            DirectorApprovalDate = request.DirectorApprovalDate;
            Number = request.Number;
            DeliveryTime = request.DeliveryTime;
            Subject = request.Subject;
            SiteId = request.SitId;
            CommentForDirectorGeneral = request.CommentForDirectorGeneral;

            ApprovalOfTechExpertIsRequired = request.ApprovalOfTechExpertIsRequired;

            if (request.Sit != null) SiteName = request.Sit.Title;

            ResultCentreId = request.ResultCentreId;
            if (request.ResultCentre != null) ResultCentreTitle = request.ResultCentre.Title;

            RationaleForInvestmentId = request.RationaleForInvestmentId;
            if (request.RationaleForInvestment != null) RationaleForInvestmentTitle = request.RationaleForInvestment.Title;

            if (request.DAIRequestsProviders != null)
            {
                Providers = request.DAIRequestsProviders.Select(p => new ProviderViewModel(p.Provider)).ToList();
            }
            else
            {
                Providers = new List<ProviderViewModel>();
            }
            if (request.DAIRequestsTechnicalService != null)
            {
                TechnicalServices = request.DAIRequestsTechnicalService.Select(t => new TechnicalServiceViewModel(t.TechnicalServ)).ToList();
            }
            else
            {
                TechnicalServices = new List<TechnicalServiceViewModel>();
            }

            TotalInvestment = request.TotalInvestment;
            EstimatedOperationPeriod = request.EstimatedOperationPeriod;
            AdditionalSalesPerYear = request.AdditionalSalesPerYear;
            MarginOnAddedValue = request.MarginOnAddedValue;
            PeriodOfPayback = request.PeriodOfPayback;
            ExtraAnnualCost = request.ExtraAnnualCost;
            NetMargin = request.NetMargin;
            InternalRateOfReturn = request.InternalRateOfReturn;
            NetPresentValue = request.NetPresentValue;
            SavingsPerYear = request.SavingsPerYear;

            ReasonForDAI = request.ReasonForDAI;

        }

        public DAIRequestViewModel() { }

        public override string ToString()
        {
            var type = typeof(DAIRequest);
            return type.FullName;
        }

        public DAIRequest CreateModel()
        {
            List<DAIRequestsProvider> providers = new List<DAIRequestsProvider>();

            if (Providers != null)
            {
                providers = Providers.Select(p => new DAIRequestsProvider() { DaiId = Id, ProviderId = p.Id }).ToList();
            }

            return new DAIRequest()
            {
                Id = Id,
                CreationData = new DateTime?(DateTime.Parse(CreationData)),
                LastModifiedData = new DateTime?(DateTime.Parse(LastModifiedData)),
                SitId = SiteId,
                ResultCentreId = ResultCentreId,
                ApprovalOfTechExpertIsRequired = ApprovalOfTechExpertIsRequired,
                RationaleForInvestmentId = RationaleForInvestmentId,
                DeliveryTime = DeliveryTime,
                DirectorApprovalDate = DirectorApprovalDate,

                TotalInvestment = TotalInvestment,
                EstimatedOperationPeriod = EstimatedOperationPeriod,
                AdditionalSalesPerYear = AdditionalSalesPerYear,
                MarginOnAddedValue = MarginOnAddedValue,
                PeriodOfPayback = PeriodOfPayback,
                ExtraAnnualCost = ExtraAnnualCost,
                NetMargin = NetMargin,
                InternalRateOfReturn = InternalRateOfReturn,
                NetPresentValue = NetPresentValue,
                SavingsPerYear = SavingsPerYear,

                ReasonForDAI = ReasonForDAI,

                CommentForDirectorGeneral = CommentForDirectorGeneral,
                DAIRequestsProviders = providers,
                Subject = Subject
            };
        }

    }
}
