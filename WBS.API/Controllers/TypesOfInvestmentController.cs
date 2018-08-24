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
    public class TypesOfInvestmentController : AbstractBaseTableController<TypeOfInvestment,TypesOfInvestmentViewModel>
    {
        public TypesOfInvestmentController(AbstractDAL<TypeOfInvestment> dal, ILogger<TypesOfInvestmentController> logger): base(dal, logger)
        {
        }

        [HttpGet("typesofinvestmentSelection")]
        [Authorize]
        public IActionResult GetTypesOfInvestmentForSelection()
        {
            _logger.LogInformation(nameof(GetTypesOfInvestmentForSelection));
            var result = _dal.Get().Select(c => new TypesOfInvestmentViewModel(c)).ToList();
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}