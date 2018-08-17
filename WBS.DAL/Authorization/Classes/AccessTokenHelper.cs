using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using WBS.DAL.Authorization.Models;

namespace WBS.DAL.Authorization
{
    class AccessTokenHelper
    {
        private readonly AuthOptions _options;

        public AccessTokenHelper(IServiceProvider provider)
        {
            _options = provider.GetService(typeof(AuthOptions)) as AuthOptions;
        }
        public AccessTokenData CreateJwt(User user, string refresh_token)
        {
            var now = DateTime.UtcNow;

            //создаем список Claim-ов
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
            };

            //получаем список ролей пользователя и добавляем их в список Claim-ов  
            var roles = user.UserRoles.Select(u => u.Role).ToList();
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Title));
            }

            var expires = now.Add(_options.ACCESS_LIFETIME);
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _options.ISSUER,
                    audience: _options.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: expires,
                    signingCredentials: new SigningCredentials(_options.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new AccessTokenData
            {
                AccessToken = encodedJwt,
                ExpiresIn = expires.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds,
            };

        }


    }
}
