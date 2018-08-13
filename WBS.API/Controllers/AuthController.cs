using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Exceptions;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly WBSContext _context;
        private readonly IServiceProvider _provider;
        private readonly ProfilesDAL _dal;
        private readonly ILogger<AuthController> _logger;
        //private readonly RefreshTokenDAL _refreshTokenDAL;

        public AuthController(WBSContext context, IServiceProvider provider, ProfilesDAL dal, ILogger<AuthController> logger)
        {
            _context = context;
            _provider = provider;
            _dal = dal;
            _logger = logger;
        }

        //TODO: переделать текущую авторизауию под то, что закоментировано
        //Возможно (крайне вероятно) нужно поменять GET на POST для увеличения уровня безопасности передаваемых персональных данных

        //[HttpGet("login")]
        //public IActionResult Login([FromQuery]string login, string password)
        //{
        //    if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        //    {
        //        var error = "Arguments of authRequest is null";
        //        _logger.LogInformation(error);
        //        return BadRequest(new ResponseError(error));
        //    }

        //    _logger.LogInformation("Start login for user: '{login}'", login);
        //    var tokenData = new AuthUtils(_profileDAL, _refreshTokenDAL, _provider).CreateToken(login, password);
        //    _logger.LogInformation("User login is successful");
        //    return Ok(tokenData);
        //}

        //[HttpGet("token")]
        //public IActionResult UpdateAccessToken([FromQuery]string refreshToken)
        //{
        //    if (string.IsNullOrEmpty(refreshToken))
        //    {
        //        var error = "RefreshToken argument is null or empty. Can not update access token.";
        //        _logger.LogInformation(error);
        //        return BadRequest(new ResponseError(error));
        //    }

        //    _logger.LogInformation("Update Access Token start");
        //    var tokenData = new AuthUtils(_profileDAL, _refreshTokenDAL, _provider).UpdateAccessToken(refreshToken);
        //    _logger.LogInformation("Update Access Token is successful");
        //    return Ok(tokenData);
        //}

        [HttpPost("login")]
        public IActionResult Login([FromBody]AuthRequest data)
        {       
            _logger.LogInformation("Start login for user: '{login}'", data.Login);
            var tokenData = new AuthUtils(_context, _provider).CreateToken(data.Login, data.Password);
            _logger.LogInformation("User login is successful");
            return Ok(tokenData);
        }

        [HttpPost("token")]
        public IActionResult UpdateAccessToken([FromBody]TokenRequest refreshToken)
        {
            _logger.LogInformation("Update Access Token start");
            var tokenData = new AuthUtils(_context, _provider).UpdateAccessToken(refreshToken.TokenString);
            _logger.LogInformation("Update Access Token is successful");
            return Ok(tokenData);
        }      
    }
}