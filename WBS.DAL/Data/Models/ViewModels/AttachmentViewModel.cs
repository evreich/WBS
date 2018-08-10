using System;
using System.Collections.Generic;
using System.Text;

namespace WBS.DAL.Data.Models.ViewModels
{
    public class AttachmentViewModel : IViewModel<Attachment>
    {
        public int Id { get; set; }
        public int? DaiId { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }

        public AttachmentViewModel() { }

        public AttachmentViewModel(Attachment attachment)
        {
            Id = attachment.Id;
            DaiId = attachment.DaiId;
            Data = attachment.Data;
            FileName = attachment.FileName;
        }

        public Attachment CreateModel()
        {
            return new Attachment()
            {
                Id = Id,
                DaiId = DaiId,
                Data = Data,
                FileName = FileName
            };
        }
    }
}
