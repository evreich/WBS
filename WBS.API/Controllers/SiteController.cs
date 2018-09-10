using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Classes;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SiteController : AbstractBaseTableController<Site,SitViewModel, SiteDAL>
    {
        public SiteController(ICRUD<Site> dal, ILogger<SiteController> logger)
            : base(dal, logger)
        {
        }

        [HttpGet("sitsSelection")]
        [Authorize]
        public IActionResult GetSitsForSelection()
        {
            _logger.LogInformation(nameof(GetSitsForSelection));
            var result = _baseDAL.Get().Select(c => new SitsForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}