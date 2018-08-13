using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using WBS.API.Controllers;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Models;
using Xunit;
using WBS.Tests.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WBS.DAL.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Authorization.Classes;

namespace WBS.Tests.Tests
{
    /*
    public class AuthControllerTests
    {
        private readonly AuthController authController;
        private readonly RefreshToken refreshToken;
        private readonly RefreshToken expiredRefreshToken;
        private readonly Mock<WBSContext> contextMock;
        private readonly Mock<ICache> cacheMock;

        private const int countUsers = 20;
        private const string KEY = "BGTnhyMJU100-BGTnhyMJU100-BGTnhyMJU100";
        
        public AuthControllerTests()
        {
            var usersList = GetUsers();
            var usersDbSet = MockHelper.MockDbSet(usersList);

            cacheMock = new Mock<ICache>();
            contextMock = new Mock<WBSContext>();
            contextMock.Setup(db => db.Profiles).Returns(usersDbSet.Object);
            contextMock.Setup(db => db.Set<User>()).Returns(usersDbSet.Object);

            //TODO: Переписать
            refreshToken = GetRefreshToken(DateTime.UtcNow.AddSeconds(30), "user1");
            expiredRefreshToken = GetRefreshToken(DateTime.UtcNow.AddMilliseconds(5), "user2");
            var refreshTokensList = new List<RefreshToken>() { refreshToken, expiredRefreshToken };
            var refreshTokensDbSet = MockHelper.MockDbSet(refreshTokensList);
            contextMock.Setup(db => db.RefreshTokens).Returns(refreshTokensDbSet.Object);

            var providerMock = GetProviderMock();
            var loggerMock = new Mock<ILogger<AuthController>>();
            var profilesDALMock = GetProfilesDALMock(usersList);
            var refreshTokenDALMock = GetRrefreshTokenDALMock(refreshTokensList);

            authController = new AuthController(providerMock.Object, profilesDALMock.Object,
                                                refreshTokenDALMock.Object, loggerMock.Object);
        }

        #region Utils

        private List<User> GetUsers()
        {
            var role = new Role() { Id = 1, Title = "User" };
            var usersList = new List<User>();
            for (int i = 1; i <= countUsers; i++)
            {
                var user = new User
                {
                    Id = i,
                    Login = $"user{i}",
                    Password = $"12345",
                    UserRoles = new List<UserRoles> { new UserRoles() { Id = i, Role = role, RoleId = 1, UserId = i } }
                };

                var passwordHash = new PasswordHasher<User>().HashPassword(user, user.Password);
                user.Password = passwordHash;
                usersList.Add(user);
            }

            return usersList;
        }

        private Mock<IConfiguration> GetConfigMock()
        {
            Dictionary<string, string> sections = new Dictionary<string, string>
            {
                { "ISSUER", "QPDevWBS"},
                { "AUDIENCE", "Clients"},
                { "KEY", KEY},
                { "ACCESS_LIFETIME", "00:00:30"},
                { "REFRESH_LIFETIME", "00:01:00"}
            };

            var configSectionMock = new Mock<IConfigurationSection>();
            foreach (var s in sections)
            {
                var mock = new Mock<IConfigurationSection>();
                mock.Setup(m => m.Value).Returns(s.Value);
                configSectionMock
                    .Setup(c => c.GetSection(s.Key))
                    .Returns(mock.Object);
            }

            var configMock = new Mock<IConfiguration>();
            configMock
                .Setup(c => c.GetSection("AuthSettings"))
                .Returns(configSectionMock.Object);
            return configMock;
        }

        private Mock<IServiceProvider> GetProviderMock()
        {
            var providerMock = new Mock<IServiceProvider>();
            var configMock = GetConfigMock();
            providerMock
                .Setup(x => x.GetService(typeof(AuthOptions)))
                .Returns(new AuthOptions(configMock.Object));

            return providerMock;
        }

        private Mock<ProfilesDAL> GetProfilesDALMock(List<User> usersList)
        {
            var hasher = new PasswordHasher<User>();

            var profilesDALMock = new Mock<ProfilesDAL>(contextMock.Object, cacheMock.Object);
            profilesDALMock.Setup(p => p.Get(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string l, string p) => usersList.Find(u => u.Login.Equals(l, StringComparison.InvariantCultureIgnoreCase)
                    && hasher.VerifyHashedPassword(u, u.Password, p) == PasswordVerificationResult.Success));
            profilesDALMock.Setup(p => p.GetByLogin(It.IsAny<string>()))
                .Returns((string l) => usersList.Find(u => u.Login.Equals(l, StringComparison.InvariantCultureIgnoreCase)));
            return profilesDALMock;
        }

        private Mock<RefreshTokenDAL> GetRrefreshTokenDALMock(List<RefreshToken> refreshTokensList)
        {
            var refreshTokenDALMock = new Mock<RefreshTokenDAL>(contextMock.Object, cacheMock.Object);
            refreshTokenDALMock
                .Setup(r => r.Add(It.IsAny<RefreshToken>()))
                .Returns((RefreshToken r) => r);
            refreshTokenDALMock
                .Setup(r => r.GetByAudience(It.IsAny<string>()))
                .Returns((string a)=>refreshTokensList.Find(r => r.Audience.Equals(a, StringComparison.InvariantCultureIgnoreCase)));

            return refreshTokenDALMock;
        }

        private RefreshToken GetRefreshToken(DateTime expire, string user)
        {
            var now = DateTime.UtcNow;
            //var expire = now.AddMinutes(1);
            var tokenId = $"{Guid.NewGuid()}_{user}";
            var token = new JwtSecurityToken(
                audience: tokenId,
                issuer: "QPDevWBS",
                notBefore: now,
                expires: expire,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY)), SecurityAlgorithms.HmacSha256));
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new RefreshToken() { 
            //Id = 1, 
            Expire = expire, Token = tokenString, Audience = tokenId };
        }

        #endregion Utils


        #region Tests

        [Theory]
        [InlineData(null, "12345")]
        [InlineData("user1", null)]
        [InlineData(null, null)]
        public void Login_WithNullValues_ReturnsBadRequest(string login, string password)
        {
            var response = authController.Login(login, password);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Theory]
        [InlineData("user0", "12345")]
        [InlineData("user1", "1234")]
        [InlineData("user0", "1234")]
        public void Login_WithInvalidValues_ReturnsBadRequest(string login, string password)
        {
            Action action = () => authController.Login(login, password);

            Assert.Throws<UserNotFoundException>(action);
        }

        [Fact]
        public void Login_WithCorrectValue_ReturnsOk()
        {
            var response = authController.Login("user1", "12345");

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void UpdateAccessToken_WithEmptyRefreshToken_ReturnsBadRequest()
        {
            var response = authController.UpdateAccessToken(null);

            Assert.IsType<BadRequestObjectResult>(response);
        }

        [Fact]
        public void UpdateAccessToken_WithExpiredRefreshToken_ThrowsRefreshTokenExpiredException()
        {
            Action action = () => authController.UpdateAccessToken(expiredRefreshToken.Token);

            Assert.Throws<RefreshTokenExpiredException>(action);
        }

        [Fact]
        public void UpdateAccessToken_WithInvalidRefreshToken_ThrowsRefreshTokenExpiredException()
        {
            Action action = () => authController.UpdateAccessToken("xxxxyyyyzzzz");

            Assert.Throws<RefreshTokenExpiredException>(action);
        }

        [Fact]
        public void UpdateAccessToken_WithCorrectRefreshToken_ReturnsOk()
        {
            var response = authController.UpdateAccessToken(refreshToken.Token);

            Assert.IsType<OkObjectResult>(response);
        }

        #endregion Tests
    }
*/
}
