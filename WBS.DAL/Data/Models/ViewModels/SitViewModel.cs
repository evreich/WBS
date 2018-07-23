using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
   
    public class SitViewModel : IViewModel<Site>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? FormatId { get; set; }
        public string FormatTitle { get; set; }

        public int? KySitId { get; set; }
        public string KySitFio { get; set; }

        public int? TechnicalExpertId { get; set; }
        public string TechnicalExpertFio { get; set; }

        public int? DirectorOfSitId { get; set; }
        public string DirectorOfSitFio { get; set; }

        public int? CreaterOfBudgetId { get; set; }
        public string CreaterOfBudgetFio { get; set; }

        public int? KyRegionId { get; set; }
        public string KyRegionFio { get; set; }

        public int? OperationDirectorId { get; set; }
        public string OperationDirectorFio { get; set; }

        public SitViewModel(Site sit)
        {
            Id = sit.Id;
            Title = sit.Title;

            FormatId = sit.FormatId;
            if (sit.Format != null) FormatTitle = sit.Format.Title;

            KySitId = sit.KySitId;
            if (sit.KySit != null) KySitFio = sit.KySit.Fio;

            TechnicalExpertId = sit.TechnicalExpertId;
            if (sit.TechnicalExpert != null) TechnicalExpertFio = sit.TechnicalExpert.Fio;

            DirectorOfSitId = sit.DirectorOfSitId;
            if (sit.DirectorOfSit != null) DirectorOfSitFio = sit.DirectorOfSit.Fio;

            CreaterOfBudgetId = sit.CreaterOfBudgetId;
            if (sit.CreaterOfBudget != null) CreaterOfBudgetFio = sit.CreaterOfBudget.Fio;

            KyRegionId = sit.KyRegionId;
            if (sit.KyRegion != null) KyRegionFio = sit.KyRegion.Fio;

            OperationDirectorId = sit.OperationDirectorId;
            if (sit.OperationDirector != null) OperationDirectorFio = sit.OperationDirector.Fio;
        }

        public SitViewModel()
        {
        }

        public Site CreateModel()
        {
            return new Site
            {
                Id = Id,
                Title = Title,
                FormatId = FormatId,
                KySitId = KySitId,
                TechnicalExpertId = TechnicalExpertId,
                DirectorOfSitId = DirectorOfSitId,
                CreaterOfBudgetId = CreaterOfBudgetId,
                KyRegionId = KyRegionId,
                OperationDirectorId = OperationDirectorId
            };
        }
    }
}
