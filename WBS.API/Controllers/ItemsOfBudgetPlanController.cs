using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Data.Classes;
using WBS.DAL.Layers.Classes;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsOfBudgetPlanController : AbstractBaseTableController<ItemOfBudgetPlan, ItemOfBudgetPlanViewModel, ItemsOfBudgetPlanDAL>
    {
        public ItemsOfBudgetPlanController(ICRUD<ItemOfBudgetPlan> baseDAL, ILogger<ItemsOfBudgetPlanController> logger)
            : base(baseDAL, logger)
        {

        }

        [Authorize]
        [HttpGet("{siteId}/{budgetPlanId}/{currentPage}/{pageSize}")]
        public IActionResult Get(int siteId, int budgetPlanId, int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");
            var allData = _baseDAL.Get().Where(item => item.BudgetPlanId == budgetPlanId && item.SiteId == siteId)
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