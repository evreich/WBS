using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;

namespace WBS.DAL.Authorization.Classes
{
    public class RefreshTokenDAL
    {
        readonly WBSContext _context;
        readonly ICache _cache;

        public RefreshTokenDAL(WBSContext context, ICache cache)
        {
            _cache = cache;
            _context = context;
        }


        public virtual RefreshToken GetByAudience(string audience)
        {
            return _cache.Get(audience, param =>
            {
                return _context.RefreshTokens
                .FirstOrDefault(_t => _t.Audience.Equals(audience, StringComparison.InvariantCultureIgnoreCase));
            });
        }

        public virtual RefreshToken Add(RefreshToken token)
        {
            var tokenEntityEntry = _context.RefreshTokens.Add(token);
            _context.SaveChanges();
            tokenEntityEntry.Reload();
            _cache.Add(token.Token, tokenEntityEntry.Entity);
            return tokenEntityEntry.Entity;
        }

        public virtual RefreshToken Remove(int id)
        {
            var result = _context.RefreshTokens.Where(p => p.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.RefreshTokens.Remove(result);
                _context.SaveChanges();
                _cache.Remove(result);
            }
            return result;
        }

        public virtual RefreshToken Remove(RefreshToken token)
        {
            _context.RefreshTokens.Remove(token);
            _context.SaveChanges();
            _cache.Remove(token);
            return token;
        }



    }
}
