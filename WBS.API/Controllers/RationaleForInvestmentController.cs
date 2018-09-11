using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RationaleForInvestmentController : AbstractBaseTableController<RationaleForInvestment, RationaleForInvestmentViewModel, RationaleForInvestmentsDAL>
    {
        public RationaleForInvestmentController(ICRUD<RationaleForInvestment> dal, ILogger<RationaleForInvestmentController> logger)
            : base(dal, logger)
        {
        }

        [HttpGet("investmentRationaleSelection")]
        [Authorize]
        public IActionResult GetInvestmentRationaleForSelection()
        {
            _logger.LogInformation(nameof(GetInvestmentRationaleForSelection));
            var result = _baseDAL.Get().Select(c => new InvestmentRationaleForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}