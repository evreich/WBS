using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Classes;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IServiceProvider _provider;
        private readonly ProfilesDAL _profileDAL;
        private readonly RefreshTokenDAL _refreshTokenDAL;
        private readonly IPermissionsDAL _permissionsDAL;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IServiceProvider provider, ProfilesDAL profileDAL, IPermissionsDAL permissionsDAL, RefreshTokenDAL refreshTokenDAL, ILogger<AuthController> logger)
        {
            _provider = provider;
            _profileDAL = profileDAL;
            _permissionsDAL = permissionsDAL;
            _refreshTokenDAL = refreshTokenDAL;
            _logger = logger;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody]AuthRequest data)
        {
            _logger.LogInformation("Start login for user: '{login}'", data.Login);
            var tokenData = new AuthUtils(_profileDAL, _refreshTokenDAL, _permissionsDAL, _provider).CreateToken(data.Login, data.Password);
            _logger.LogInformation("User login is successful");
            return Ok(tokenData);
        }


        [HttpGet("token")]
        public IActionResult UpdateAccessToken([FromQuery]string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                var error = "RefreshToken argument is null or empty. Can not update accsess token.";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            _logger.LogInformation("Update Access Token start");
            var tokenData = new AuthUtils(_profileDAL, _refreshTokenDAL, _permissionsDAL, _provider).UpdateAccessToken(refreshToken);
            _logger.LogInformation("Update Access Token is successful");
            return Ok(tokenData);
        }

    }
}