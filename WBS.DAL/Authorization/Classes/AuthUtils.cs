using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WBS.DAL.Cache;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Exceptions;

namespace WBS.DAL.Authorization
{
    public class AuthUtils
    {
        private readonly WBSContext _context;
        private readonly AuthOptions _options;
        private readonly ICache _cache;
        private readonly IServiceProvider _provider;

        public AuthUtils(WBSContext context, IServiceProvider provider)
        {
            _context = context;
            _options = provider.GetService(typeof(AuthOptions)) as AuthOptions;
            _cache = provider.GetService(typeof(ICache)) as ICache;
            _provider = provider;

            // TODO remove later
            if ((_context.Profiles.Count() == 0 ) && (context.Roles.Count() == 0) && (context.UserRoles.Count() == 0))
            {
                var hasher = new PasswordHasher<User>();
                var u1 = new User
                {
                    Login = "admin"                
                };
                u1.Password = hasher.HashPassword(u1, "12345");
                var u2 = new User
                {
                    Login = "user"                  
                };
                u2.Password = hasher.HashPassword(u2, "123");
                _context.Profiles.AddRange(u1, u2);
                _context.SaveChanges();


                var r1 = new Role
                {
                    Title = "admin"
                };

                var r2 = new Role
                {
                    Title = "user",
                    Routes = "/signup"
                };

                _context.Roles.AddRange(r1, r2);
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRoles { UserId = u1.Id, RoleId = r1.Id });
                _context.UserRoles.Add(new UserRoles { UserId = u1.Id, RoleId = r2.Id });
                _context.UserRoles.Add(new UserRoles { UserId = u2.Id, RoleId = r2.Id });

                _context.SaveChanges();
            }
        }

        public object CreateToken(string login, string password)
        {          
            var hasher = new PasswordHasher<User>();
            var user = _cache.Get(login, param => _context.Profiles
                    .Include(_p => _p.UserRoles)
                        .ThenInclude(ur => ur.Role)
                    .FirstOrDefault(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase)
                        && hasher.VerifyHashedPassword(p, p.Password, password) == PasswordVerificationResult.Success));

            if (user == null)
            {
                throw new UserNotFoundException("Invalid username or password");
            }

            var refreshTokenString = new RefreshTokenHelper(_context, _provider).Create(login);
            return CreateTokenData(user, refreshTokenString);            
        }

        public object UpdateAccessToken(string refreshTokenString)
        { 
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(refreshTokenString))
            {
                throw new RefreshTokenExpiredException("Refresh token is not correct");
            }

            var refreshToken = handler.ReadJwtToken(refreshTokenString);
            var audience = refreshToken.Audiences.FirstOrDefault();
            var savedRefreshToken = _context.RefreshTokens.FirstOrDefault(_t => _t.Audience.Equals(audience, StringComparison.InvariantCultureIgnoreCase));

            if (savedRefreshToken == null)
            {
                throw new RefreshTokenExpiredException("Refresh token cant find in database");
            }

            var refreshTokenHelper = new RefreshTokenHelper(_context, _provider);
            var isValid = refreshTokenHelper.Validate(refreshToken);

            if (!isValid)
            {
                throw new RefreshTokenExpiredException("Refresh token is expired");
            }

            var login = audience.Split("_", StringSplitOptions.RemoveEmptyEntries)[1];
            var user = _context.Profiles.Include(_p => _p.UserRoles).ThenInclude(u=> u.Role).FirstOrDefault(_p => _p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase));
            var newRefreshToken = refreshTokenHelper.Create(login);
            return CreateTokenData(user, newRefreshToken);
        }

        private object CreateTokenData(User user, string refreshTokenString)
        {
            var tokenString = new AccessTokenHelper(_provider).Create(user);

            var response = new
            {
                access_token = tokenString,
                refresh_token = refreshTokenString,
                username = user.Login,
                role = String.Join(", ", user.UserRoles.Select(u=> u.Role.Title).ToArray())             
            };

            return response;
        }
    }
}
