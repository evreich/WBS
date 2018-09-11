using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ResultCentresController : AbstractBaseTableController<ResultCenter, ResultCentresViewModel, ResultCentresDAL>
    {
        public ResultCentresController(ICRUD<ResultCenter> dal, ILogger<ResultCentresController> logger)
            : base(dal, logger)
        {
        }

        [HttpGet("resCentresSelection")]
        [Authorize]
        public IActionResult GetResCentresForSelection()
        {
            _logger.LogInformation(nameof(GetResCentresForSelection));
            var result = _baseDAL.Get().Select(c => new ResultCentresForSelection(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}