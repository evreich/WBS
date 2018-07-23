using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WBS.DAL.Authorization
{
    public class AuthOptions
    {
        public AuthOptions(IConfiguration configuration)
        {
            var settings = configuration.GetSection("AuthSettings");
            ISSUER = settings.GetSection("ISSUER").Value;
            AUDIENCE = settings.GetSection("AUDIENCE").Value;
            KEY = settings.GetSection("KEY").Value;
            // hardcode default value
            TimeSpan.TryParse(settings.GetSection("ACCESS_LIFETIME").Value, out TimeSpan accessEexpiration);
            ACCESS_LIFETIME = accessEexpiration == null ? new TimeSpan(0, 5, 0) : accessEexpiration;

            TimeSpan.TryParse(settings.GetSection("REFRESH_LIFETIME").Value, out TimeSpan refreshExpiration);
            REFRESH_LIFETIME = refreshExpiration == null ? new TimeSpan(3, 0, 0) : refreshExpiration;
        }

        public readonly string ISSUER; // издатель токена
        public readonly string AUDIENCE; // потребитель токена
        private readonly string KEY; // ключ для шифрации
        public readonly TimeSpan ACCESS_LIFETIME; // время жизни токена(мин.)
        public readonly TimeSpan REFRESH_LIFETIME; // время жизни refresh токена(мин.)

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
