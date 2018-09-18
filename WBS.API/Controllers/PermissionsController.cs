using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        ILogger<PermissionsController> _logger;

        public PermissionsController(ILogger<PermissionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public virtual IActionResult GetPermissionsForType([FromServices] IPermissionsDAL permDAL, [FromQuery] string objectType)
        {
            _logger.LogInformation(nameof(GetPermissionsForType));
            var roles = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Role)
                .Select(claim => claim.Value)
                .ToList();

            var dalAssembly = Assembly.Load(Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .FirstOrDefault(a => a.FullName == "WBS.DAL"));
            var modelsTypes = dalAssembly.GetTypes().Where(type => type.Namespace == "WBS.DAL.Data.Models" ||
                                                                   type.Namespace == "WBS.DAL.Authorization.Models");

            Type typeEntity = modelsTypes.FirstOrDefault(type => type.Name == objectType);
            var perms = permDAL.GetPermissionsForType(typeEntity.FullName, typeEntity.Assembly.GetName().Name, roles);

            bool accessToCreate, accessToRead, accessToUpdate, accessToDelete;

            accessToCreate = perms.Where(p => p.AllowCreate).Any();
            accessToRead = perms.Where(p => p.AllowRead).Any();
            accessToUpdate = perms.Where(p => p.AllowWrite).Any();
            accessToDelete = perms.Where(p => p.AllowDelete).Any();

            return Ok(new { accessToCreate, accessToRead, accessToUpdate, accessToDelete });
        }
    }
}