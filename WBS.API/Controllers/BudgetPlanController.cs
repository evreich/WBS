using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BudgetPlanController: AbstractBaseTableController<BudgetPlan, BudgetPlanViewModel, BudgetPlanDAL>
    {
        public BudgetPlanController(ICRUD<BudgetPlan> baseDAL, ILogger<BudgetPlanController> logger)
       : base(baseDAL, logger)
        {
        }

        [HttpGet("{currentPage}/{pageSize}")]
        [Authorize]
        public override IActionResult Get(int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");

            var allData = _baseDAL.Get()
                        .OrderBy(f => f.Id);
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(bp => new BudgetPlanViewModel(bp.Id, bp.Year, _baseDAL.GetStatusOfPlan(bp.Id).Title));

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<BudgetPlanViewModel>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }

        [HttpPost]
        [Authorize]
        public override IActionResult Post([FromBody] BudgetPlanViewModel value)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (value == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            if (_baseDAL.IsAlreadyHaveInDb(value.Year))
            {
                var error = "Бюджетный план на заданный год уже существует в базе данных";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            _logger.LogInformation("Create '{dataId}' data", value.Id);
            value.Status = Constants.STATUS_BP_PROJECT;
            var createdData = _baseDAL.Create(value.CreateModel());
            if (createdData == null)
            {
                throw new Exception("Create is not successful");
            }
            _logger.LogInformation("Create is successful");

            var uri = new Uri($"{HttpContext.Request.Host}{HttpContext.Request.Path.Value}");
            return Created(uri, new BudgetPlanViewModel(createdData.Id, createdData.Year, _baseDAL.GetStatusOfPlan(createdData.Id).Title));
        }
    }
}
