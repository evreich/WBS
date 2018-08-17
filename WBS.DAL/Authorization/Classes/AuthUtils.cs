using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using WBS.DAL.Cache;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Exceptions;
using WBS.DAL.Authorization.Models.ViewModels;
using WBS.DAL.Authorization.Classes;

namespace WBS.DAL.Authorization
{
    public class AuthUtils
    {
        private readonly ProfilesDAL _profilesDal;
        private readonly RefreshTokenDAL _refreshTokenDal;
        private readonly AuthOptions _options;
        private readonly ICache _cache;
        private readonly IServiceProvider _provider;

        public AuthUtils(ProfilesDAL profilesDal, RefreshTokenDAL refreshTokenDal, IServiceProvider provider)
        {
            _profilesDal = profilesDal;
            _refreshTokenDal = refreshTokenDal;
            _options = provider.GetService(typeof(AuthOptions)) as AuthOptions;
            _cache = provider.GetService(typeof(ICache)) as ICache;
            _provider = provider;
        }

        public TokenViewModel CreateToken(string login, string password)
        {
            var hasher = new PasswordHasher<User>();
            var user = _profilesDal.Get(login, password);
            if (user == null)
            {
                throw new UserNotFoundException("Invalid username or password  ");
            }
            return CreateResponse(_refreshTokenDal, user);
        }

        public TokenViewModel CreateResponse(RefreshTokenDAL tokenDAL, User user)
        {
            var refreshToken = new RefreshTokenHelper(tokenDAL, _provider).Create(user.Login);
            var accessToken = new AccessTokenHelper(_provider).CreateJwt(user, refreshToken);
            return new TokenViewModel
            {
                AccessToken = accessToken.AccessToken,
                ExpiresIn = accessToken.ExpiresIn,
                RefreshToken = refreshToken,
                Username = user.Login,
                Roles = String.Join(", ", user.UserRoles.Select(u => u.Role.Title).ToArray())
            };
        }

        public TokenViewModel UpdateAccessToken(string refreshTokenString)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(refreshTokenString))
            {
                throw new RefreshTokenExpiredException("Refresh token is not correct");
            }

            var refreshToken = handler.ReadJwtToken(refreshTokenString);
            var audience = refreshToken.Audiences.FirstOrDefault();
            var savedRefreshToken = _refreshTokenDal.GetByAudience(audience);

            if (savedRefreshToken == null)
            {
                throw new RefreshTokenExpiredException("Refresh token cant find in database");
            }
            _refreshTokenDal.Remove(savedRefreshToken);

            if (RefreshTokenHelper.IsExpired(savedRefreshToken))
            {
                throw new RefreshTokenExpiredException("Refresh token is expired");
            }

            var login = audience.Split("_", StringSplitOptions.RemoveEmptyEntries)[1];
            var user = _profilesDal.GetByLogin(login);
            return CreateResponse(_refreshTokenDal, user);
        }

    }
}
