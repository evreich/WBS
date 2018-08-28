using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TechnicalServiceController : AbstractBaseTableController<TechnicalService, TechnicalServiceViewModel>
    {
        public TechnicalServiceController(AbstractDAL<TechnicalService> dal, ILogger<TechnicalServiceController> logger) : base(dal, logger)
        {
        }

        [HttpGet("technicalServsSelection")]
        [Authorize]
        public IActionResult GetTechnicalServiceForSelection()
        {
            _logger.LogInformation(nameof(GetTechnicalServiceForSelection));
            var result = _dal.Get().ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}