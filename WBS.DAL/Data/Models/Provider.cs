using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;

namespace WBS.DAL.Data.Models
{
    public class Provider : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
     
        public List<ProvidersTechnicalService> ProvidersTechnicalServices { get; set; }

        public Provider()
        {
            ProvidersTechnicalServices = new List<ProvidersTechnicalService>();
        }

        public override string ToString()
        {
            var type = typeof(Provider);
            return type.FullName;
        }
    }
}
