using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBS.API.Helpers;
using WBS.DAL.Data.Classes;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestLineController : AbstractBaseTableController<RequestLine, RequestLineViewModel, RequestLineDAL>
    {
        public RequestLineController(ICRUD<RequestLine> baseDAL, ILogger<RequestLineController> logger): base(baseDAL, logger)
        {

        }

        [Authorize]
        [HttpGet("{siteId}/{requestId}/{currentPage}/{pageSize}")]
        public IActionResult Get(int siteId, int requestId, int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");
            var allData = _baseDAL.Get().Where(item => item.RequestId == requestId && item.SiteId == siteId)
                        .OrderBy(f => f.Id);
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(rl => new RequestLineViewModel(rl));

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<RequestLineViewModel>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }
    }
}
