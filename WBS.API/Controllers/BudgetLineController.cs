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
using WBS.DAL.Enums;
using System;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetLineController : AbstractBaseTableController<BudgetLine, BudgetLineViewModel, BudgetLineDAL>
    {
        public BudgetLineController(ICRUD<BudgetLine> baseDAL, ILogger<BudgetLineController> logger)
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
                            .Select(bp => new BudgetLineViewModel(bp));

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<BudgetLineViewModel>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }

        [HttpGet("monthsSelection")]
        [Authorize]
        public IActionResult GetMonthsForSelection()
        {
            _logger.LogInformation(nameof(GetMonthsForSelection));
            var result = Enum.GetValues(typeof(Month))
                        .Cast<Month>()
                        .Select(m => new 
                        {
                            Id = ((int)m).ToString(),
                            Title = m.GetEnumDisplayName()
                        });
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}