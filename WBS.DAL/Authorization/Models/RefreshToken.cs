using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Models
{
    public class RefreshToken
    {
        [Key, Column("token")]
        public string Token { get; set; }

        [Column("expire")]
        public DateTime Expire { get; set; }

        /// <summary>
        /// Потребитель, будет уникальный для быстрого поиска. 
        /// Формат: GUID_login
        /// </summary>
        [Column("audience")]
        public string Audience { get; set; }
    }
}
