using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using WBS.DAL;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Data.Models;

namespace WBS.DAL.Models
{
   
    public class Format : IBaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id")]
        public int Id { get; set; }
   
        public string Title { get; set; }
 
        public string Profile { get; set; }
    
        public string TypeOfFormat { get; set; }
     
        public int E1Limit { get; set; }
    
        public int E2Limit { get; set; }
 
        public int E3Limit { get; set; }

        //relationships
        public int? DirectorOfFormatId { get; set; }
        public User DirectorOfFormat { get; set; }

        public int? DirectorOfKYFormatId { get; set; }
        public User DirectorOfKYFormat { get; set; }

        public int? KYFormatId { get; set; }
        public User KYFormat { get; set; }

        public List<Data.Models.Site> Sites { get; set; }

        public Format()
        {
            Sites = new List<Data.Models.Site>();
        }

        public override string ToString()
        {
            var type = typeof(Format);
            return type.FullName;
        }
    }
}
