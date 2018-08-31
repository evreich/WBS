using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DAIRequestController : AbstractBaseTableController<DAIRequest, DAIRequestViewModel>
    {
        private readonly DAIRequestDAL _daiRequestDAL;
        public DAIRequestController(AbstractDAL<DAIRequest> daiRequestDAL, ILogger<DAIRequestController> logger) : base(daiRequestDAL, logger)
        {
            if (!(_dal is DAIRequestDAL dal))
            {       
                var error = "Преобразование abstract DAL к потомку не удалось";
                _logger.LogError(error);
                throw new Exception(error);
            }
            _daiRequestDAL = dal;
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

            var createdData = _daiRequestDAL.Create(daiModel);

            if (createdData != null)
            {
                _daiRequestDAL.AddTechnicalServs(daiModel.Id, value.TechnicalServices);
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
            var updatedData = _dal.Update(daiModel);

            if (updatedData != null)
            {
                _daiRequestDAL.AddTechnicalServs(daiModel.Id, value.TechnicalServices);
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