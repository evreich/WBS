using System.Linq;
using Microsoft.AspNetCore.Authorization;
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