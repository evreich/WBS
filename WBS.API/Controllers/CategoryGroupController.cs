using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using System.Security.Claims;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/CategoryGroup")]
    public class CategoryGroupController : AbstractBaseTableController<CategoryGroup,CategoryGroupsViewModel>
    {

        public CategoryGroupController(AbstractDAL<CategoryGroup> dal, ILogger<CategoryGroupController> logger): base(dal,logger)
        {
        }

        [HttpGet("categoriesSelection")]
        [Authorize(Roles = "admin")]
        public IActionResult GetCategoriesForSelection()
        {
            _logger.LogInformation(nameof(GetCategoriesForSelection));
            var result = _dal.Get().Select(c => new CategoryGroupsViewModel(c));
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}