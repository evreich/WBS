using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Descriptors;
using WBS.DAL.Enums;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptorController : ControllerBase
    {
        ILogger<DescriptorController> _logger;

        public DescriptorController(ILogger<DescriptorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDescriptor([FromServices] DescriptorOfFormGenerator descriptorCreator, 
            [FromQuery]string objectType, [FromQuery]int id = 0)
        {
            _logger.LogInformation(nameof(GetDescriptor));
            
            var roles = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Role)
                .Select(claim => claim.Value)
                .ToList();

            if (roles == null || roles.Count() == 0)
                return BadRequest(new ResponseError("Роли пользователя отсутствуют"));

            Type typeEntity;
            try
            {
                var dalAssembly = Assembly.Load(Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                    .FirstOrDefault(a => a.Name == "WBS.DAL"));
                var modelsTypes = dalAssembly.GetTypes().Where(type => type.Namespace == "WBS.DAL.Data.Models" ||
                                                                       type.Namespace == "WBS.DAL.Authorization.Models");
                typeEntity = modelsTypes.FirstOrDefault(type => type.Name == objectType);
            }
            catch(ArgumentNullException)
            {
                return BadRequest(new ResponseError("Данный тип не является частью системы."));
            }

            var targetOfForm = id == 0 ? TypeOfDescriptor.AddingForm : TypeOfDescriptor.EditForm;
            try
            {
                var descriptor = descriptorCreator.CreateDescriptor(typeEntity, targetOfForm, roles);

                var descriptorJSON = DescriptorConverter.ConvertToJSON(descriptor);
                return Ok(descriptorJSON);
            }
            catch (TypeAccessException)
            {
                return Forbid("Отсутствует доступ к данному типу");
            }
        }
    }
}