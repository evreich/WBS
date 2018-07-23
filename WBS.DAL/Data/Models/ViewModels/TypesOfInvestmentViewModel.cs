using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class TypesOfInvestmentViewModel: IViewModel<TypeOfInvestment>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string ExternalCode { get; set; }

        public TypesOfInvestmentViewModel(TypeOfInvestment type)
        {
            Id = type.Id;
            Title = type.Title;
            Code = type.Code;
            ExternalCode = type.ExternalCode;
        }

        public TypesOfInvestmentViewModel()
        {
        }

        public TypeOfInvestment CreateModel()
        {
            return new TypeOfInvestment
            {
                Id = Id,
                Title = Title,
                Code = Code,
                ExternalCode = ExternalCode
            };
        }
    }
}
