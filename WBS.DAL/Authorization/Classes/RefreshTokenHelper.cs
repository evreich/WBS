using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Authorization.Classes;

namespace WBS.DAL.Authorization
{
    class RefreshTokenHelper
    {
        private readonly RefreshTokenDAL _refreshTokenDAL;
        private readonly AuthOptions _options;
        public RefreshTokenHelper(RefreshTokenDAL dal, IServiceProvider provider)
        {
            _refreshTokenDAL = dal;
            _options = provider.GetService(typeof(AuthOptions)) as AuthOptions;
        }

        public string Create(string login)
        {
            var now = DateTime.UtcNow;
            var expire = now.Add(_options.REFRESH_LIFETIME);
            var tokenId = $"{Guid.NewGuid()}_{login}";
            var token = new JwtSecurityToken(
                audience: tokenId,
                issuer: _options.ISSUER,
                notBefore: now,
                expires: expire,
                signingCredentials: new SigningCredentials(_options.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            _refreshTokenDAL.Add(new RefreshToken
            {
                Audience = tokenId,
                Expire = expire,
                Token = tokenString,
            });

            return tokenString;
        }

        public bool Validate(JwtSecurityToken token)
        {
            var audience = token.Audiences.FirstOrDefault();
            var savedToken = _refreshTokenDAL.GetByAudience(audience);
            return token == null ? false : savedToken.Expire > DateTime.UtcNow;
        }

        public static bool IsExpired(RefreshToken token)
        {
            return token.Expire > DateTime.UtcNow ? false : true;
        }

    }
}
