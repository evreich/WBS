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
using WBS.DAL.Models;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FormatController : AbstractBaseTableController<Format, FormatViewModel, FormatDAL>
    {
        public FormatController(ICRUD<Format> dal, ILogger<FormatController> logger)
            : base(dal, logger)
        {
        }

        [HttpGet("formatsSelection")]
        [Authorize]
        public IActionResult GetFormatsForSelection()
        {
            _logger.LogInformation(nameof(GetFormatsForSelection));
            var result = _baseDAL.Get().Select(c => new FormatsForSelectionViewModel(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}