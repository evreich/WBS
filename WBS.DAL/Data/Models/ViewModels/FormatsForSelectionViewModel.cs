using System;
using System.Collections.Generic;
using System.Text;
using WBS.DAL;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class FormatsForSelectionViewModel : IViewModel<Format>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public FormatsForSelectionViewModel(Format format)
        {
            Id = format.Id;
            Title = format.Title;
        }

        public FormatsForSelectionViewModel()
        {
        }

        public Format CreateModel()
        {
            return new Format
            {
                Id = Id,
                Title = Title
            };
        }
    }
}
