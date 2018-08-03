using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RationaleForInvestmentController : AbstractBaseTableController<RationaleForInvestment, RationaleForInvestmentViewModel>
    {
        public RationaleForInvestmentController(AbstractDAL<RationaleForInvestment> dal, ILogger<RationaleForInvestmentController> logger): base(dal, logger)
        {
        }

        [HttpGet("investmentRationaleSelection")]
        [Authorize]
        public IActionResult GetInvestmentRationaleForSelection()
        {
            _logger.LogInformation(nameof(GetInvestmentRationaleForSelection));
            var result = _dal.Get().Select(c => new InvestmentRationaleForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}