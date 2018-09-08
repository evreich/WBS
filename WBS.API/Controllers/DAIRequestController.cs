using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DAIRequestController : AbstractBaseTableController<DAIRequest, DAIRequestViewModel, DAIRequestDAL>
    {
        public DAIRequestController(ICRUD<DAIRequest> daiRequestDAL, ILogger<DAIRequestController> logger) 
            : base(daiRequestDAL, logger)
        {
        }

        [HttpPost]
        [Authorize]
        public override IActionResult Post([FromBody] DAIRequestViewModel value)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (value == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            _logger.LogInformation("Create '{dataId}' data", value.Id);

            var daiModel = value.CreateModel();

            var createdData = _baseDAL.Create(daiModel);

            if (createdData != null)
            {
                _baseDAL.AddTechnicalServs(daiModel.Id, value.TechnicalServices);
            }
            else
            {
                throw new Exception("Create is not successful");
            }
            _logger.LogInformation("Create is successful");

            var uri = new Uri($"{HttpContext.Request.Host}{HttpContext.Request.Path.Value}");
            return Created(uri, new DAIRequestViewModel(createdData));
        }

        [HttpPut]
        [Authorize]
        public override IActionResult Put([FromBody] DAIRequestViewModel value)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (value == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            var daiModel = value.CreateModel();
            _logger.LogInformation("Change '{dataId}' data", daiModel.Id);
            var updatedData = _baseDAL.Update(daiModel);

            if (updatedData != null)
            {
                _baseDAL.AddTechnicalServs(daiModel.Id, value.TechnicalServices);
            }
            else
            {
                throw new Exception("Update is not successful");
            }
            _logger.LogInformation("Update is successful");
            return Ok(new DAIRequestViewModel(updatedData));
        }
    }
}