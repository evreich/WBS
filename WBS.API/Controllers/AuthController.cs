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

        public AuthController(WBSContext context, IServiceProvider provider, ProfilesDAL dal, ILogger<AuthController> logger)
        {
            _context = context;
            _provider = provider;
            _dal = dal;
            _logger = logger;
        }

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