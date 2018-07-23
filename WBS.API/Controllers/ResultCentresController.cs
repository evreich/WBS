using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBS.DAL;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL4.Data.Models.ViewModels;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResultCentresController : AbstractBaseTableController<ResultCenter, ResultCentresViewModel>
    {
        public ResultCentresController(AbstractDAL<ResultCenter> dal, ILogger<ResultCentresController> logger) : base(dal, logger)
        {
        }

        [HttpGet("resCentresSelection")]
        [Authorize]
        public IActionResult GetResCentresForSelection()
        {
            _logger.LogInformation(nameof(GetResCentresForSelection));
            var result = _dal.Get().Select(c => new ResultCentresForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}