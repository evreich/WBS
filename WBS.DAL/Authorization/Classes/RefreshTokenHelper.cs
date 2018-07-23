using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Exceptions;

namespace WBS.DAL.Authorization
{
    class RefreshTokenHelper
    {
        private readonly WBSContext _context;
        private readonly AuthOptions _options;
        public RefreshTokenHelper(WBSContext context, IServiceProvider provider)
        {
            _context = context;
            _options = provider.GetService(typeof(AuthOptions)) as AuthOptions;
        }

        public  string Create(string login)
        {
            FindAndRemoveInvalidOnes();

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
            try
            {             
                _context.RefreshTokens.Add(new RefreshToken
                {
                    Audience = tokenId,
                    Expire = expire,
                    Token = tokenString,
                });
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw new RefreshTokenExpiredException("Database is not responding");
            }
            return tokenString;
        }
        public bool Validate(JwtSecurityToken token)
        {
            var audience = token.Audiences.FirstOrDefault();
            var savedToken = _context.RefreshTokens
                .FirstOrDefault(_t => _t.Audience.Equals(audience, StringComparison.InvariantCultureIgnoreCase));
            return token == null ? false : savedToken.Expire > DateTime.UtcNow;
        }
        public void FindAndRemoveInvalidOnes()
        {          
            try
            {
                var now = DateTime.UtcNow;
                var invalidTokens = _context.RefreshTokens.Where(t => t.Expire <= now).ToList();
                if (invalidTokens.Count() > 0)
                {
                    _context.RefreshTokens.RemoveRange(invalidTokens);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
