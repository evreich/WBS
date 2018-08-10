using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WBS.DAL.Cache;

namespace WBS.DAL.Data.Models
{
    public class Attachment : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? DaiId { get; set; }
        public DAIRequest DAI { get; set; }

        public byte[] Data { get; set; }
        public string FileName { get; set; }

        public override string ToString()
        {
            var type = typeof(Attachment);
            return type.FullName;
        }
    }
}
