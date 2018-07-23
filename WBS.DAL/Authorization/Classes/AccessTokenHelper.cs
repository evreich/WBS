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
        public string Create(User user)
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

            // создаем JWT-токен
            var token = new JwtSecurityToken(
                    issuer: _options.ISSUER,
                    audience: _options.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(_options.ACCESS_LIFETIME),                
                    signingCredentials: new SigningCredentials(_options.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool Validate(string tokenString)
        {
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(tokenString))
            {
                var token = handler.ReadJwtToken(tokenString);
                return token.ValidTo > DateTime.UtcNow;
            }
            return false;
        }
    }
}
