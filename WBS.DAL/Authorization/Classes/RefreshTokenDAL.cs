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

        public RefreshTokenDAL(WBSContext context)
        {
            _context = context;
        }


        public virtual RefreshToken GetByAudience(string audience)
        {
                return _context.RefreshTokens
                .FirstOrDefault(_t => _t.Audience.Equals(audience, StringComparison.InvariantCultureIgnoreCase));
        }

        public virtual RefreshToken Add(RefreshToken token)
        {
            var tokenEntityEntry = _context.RefreshTokens.Add(token);
            _context.SaveChanges();
            tokenEntityEntry.Reload();
            return tokenEntityEntry.Entity;
        }

        public virtual RefreshToken Remove(int id)
        {
            var result = _context.RefreshTokens.Where(p => p.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.RefreshTokens.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public virtual RefreshToken Remove(RefreshToken token)
        {
            _context.RefreshTokens.Remove(token);
            _context.SaveChanges();
            return token;
        }



    }
}
