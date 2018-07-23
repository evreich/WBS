using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Helpers;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsOfBudgetPlanController : AbstractBaseTableController<ItemOfBudgetPlan, ItemOfBudgetPlanViewModel>
    {
        public ItemsOfBudgetPlanController(AbstractDAL<ItemOfBudgetPlan> abstractDAL, ILogger<ItemsOfBudgetPlanController> logger)
            : base(abstractDAL, logger) { }

        [Authorize]
        [HttpGet("getDetailsOfBP")]
        public IActionResult Get(int siteId, int budgetPlan, int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");
            var data = _dal.Get();
            var allData = _dal.Get().Where(item => item.BudgetPlan.Year == budgetPlan && item.SiteId == siteId)
                        .OrderBy(f => f.Id);
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(bp => new ItemOfBudgetPlanViewModel(bp));

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<ItemOfBudgetPlanViewModel>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }
         
    }
}