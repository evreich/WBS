using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class RequestLineViewModel : IViewModel<RequestLine>
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }
        public int Amortization { get; set; }

        //relationships
        public int RequestId { get; set; }
        public string Request { get; set; }

        public int BudgetLineId { get; set; }
        public string BudgetLine { get; set; }

        public int ParentRequestLineId { get; set; }
        public string ParentRequestLine { get; set; }

        public int ByWhoRequestLineId { get; set; }
        public string ByWhoRequestLine { get; set; }

        public int CategoryOfEquipmentId { get; set; }
        public string CategoryOfEquipment { get; set; }

        public int? ResultCenterId { get; set; }
        public string ResultCenter { get; set; }

        public int SiteId { get; set; }
        public string Site { get; set; }

        public int TypeOfInvestmentId { get; set; }
        public string TypeOfInvestment { get; set; }

        public RequestLineViewModel()
        {
        }

        public RequestLineViewModel(RequestLine item)
        {
            Id = item.Id;
            Title = item.Title;
            Price = item.Price;
            OldPrice = item.OldPrice;
            Quantity = item.Quantity;
            OldQuantity = item.OldQuantity;
            Amortization = item.Amortization;

            RequestId = item.RequestId;
            if (item.Request != null) Request = item.Request.Number.ToString();

            BudgetLineId = item.BudgetLineId;
            //TODO: выяснить выводимое поле
            if (item.BudgetLine != null) BudgetLine = item.BudgetLine.SubjectOfInvestment;

            ParentRequestLineId = item.ParentRequestLineId;
            if (item.ParentRequestLine != null) ParentRequestLine = item.ParentRequestLine.Title;

            ByWhoRequestLineId = item.ByWhoRequestLineId;
            if (item.ByWhoRequestLine != null) ByWhoRequestLine = item.ByWhoRequestLine.Title;

            CategoryOfEquipmentId = item.CategoryOfEquipmentId;
            if (item.CategoryOfEquipment != null) CategoryOfEquipment = item.CategoryOfEquipment.Title;

            ResultCenterId = item.ResultCenterId;
            if (item.ResultCenter != null) ResultCenter = item.ResultCenter.Title;

            SiteId = item.SiteId;
            if (item.Site != null) Site = item.Site.Title;

            TypeOfInvestmentId = item.TypeOfInvestmentId;
            if (item.TypeOfInvestment != null) TypeOfInvestment = item.TypeOfInvestment.Title;
        }

        public RequestLine CreateModel()
        {
            return new RequestLine
            {
                Id = this.Id,
                Title = this.Title,
                Price = this.Price,
                OldPrice = this.OldPrice,
                Quantity = this.OldQuantity,
                OldQuantity = this.OldQuantity,
                Amortization = this.Amortization,

                BudgetLineId = this.BudgetLineId,
                ByWhoRequestLineId = this.ByWhoRequestLineId,
                CategoryOfEquipmentId = this.CategoryOfEquipmentId,
                ParentRequestLineId = this.ParentRequestLineId,
                ResultCenterId = this.ResultCenterId,
                RequestId = this.RequestId,
                SiteId = this.SiteId,
                TypeOfInvestmentId = this.TypeOfInvestmentId
            };
        }
    }
}
