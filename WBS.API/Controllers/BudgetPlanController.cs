using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BudgetPlanController: AbstractBaseTableController<BudgetPlan, BudgetPlanViewModel>
    {
        private readonly BudgetPlanDAL _budgetPlanDAL;

        public BudgetPlanController(AbstractDAL<BudgetPlan> abstractDAL, ILogger<BudgetPlanController> logger) : base(abstractDAL, logger)
        {
            if (!(_dal is BudgetPlanDAL budgetPlanDAL))
            {
                var error = "Преобразование abstract DAL к потомку не удалось";
                _logger.LogError(error);
                throw new Exception(error);
            }
            _budgetPlanDAL = budgetPlanDAL;
        }

        [HttpGet]
        [Authorize]
        public override IActionResult Get(int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");

            var allData = _dal.Get()
                        .OrderBy(f => f.Id);
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(bp => new BudgetPlanViewModel(bp.Id, bp.Year, _budgetPlanDAL.GetStatusOfPlan(bp.Id).Title));

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

            if (_budgetPlanDAL.IsAlreadyHaveInDb(value.Year))
            {
                var error = "Бюджетный план на заданный год уже существует в базе данных";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            _logger.LogInformation("Create '{dataId}' data", value.Id);
            value.Status = Constants.STATUS_BP_PROJECT;
            var createdData = _budgetPlanDAL.Create(value.CreateModel());
            if (createdData == null)
            {
                throw new Exception("Create is not successful");
            }
            _logger.LogInformation("Create is successful");

            var uri = new Uri($"{HttpContext.Request.Host}{HttpContext.Request.Path.Value}");
            return Created(uri, new BudgetPlanViewModel(createdData.Id, createdData.Year, _budgetPlanDAL.GetStatusOfPlan(createdData.Id).Title));
        }
    }
}
