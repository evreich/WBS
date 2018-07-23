using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class ResultCentresViewModel: IViewModel<ResultCenter>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public ResultCentresViewModel(ResultCenter resCentres)
        {
            Id = resCentres.Id;
            Title = resCentres.Title;
            Code = resCentres.Code;
        }

        public ResultCentresViewModel()
        {
        }

        public ResultCenter CreateModel()
        {
            return new ResultCenter
            {
                Id = Id,
                Title = Title,
                Code = Code
            };
        }
    }
}
