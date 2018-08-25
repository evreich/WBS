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
    public class SiteController : AbstractBaseTableController<Site,SitViewModel>
    {
        public SiteController(AbstractDAL<Site> dal, ILogger<SiteController> logger) : base(dal, logger)
        {
        }

        [HttpGet("sitsSelection")]
        [Authorize]
        public IActionResult GetSitsForSelection()
        {
            _logger.LogInformation(nameof(GetSitsForSelection));
            var result = _dal.Get().Select(c => new SitsForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}