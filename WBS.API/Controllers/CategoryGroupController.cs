using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WBS.DAL;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Data.Models.ViewModels;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/CategoryGroup")]
    public class CategoryGroupController : AbstractBaseTableController<CategoryGroup,CategoryGroupsViewModel, CategoryGroupsDAL>
    {

        public CategoryGroupController(ICRUD<CategoryGroup> baseDAL, ILogger<CategoryGroupController> logger)
            : base(baseDAL,logger)
        {
        }

        [HttpGet("categoriesSelection")]
        [Authorize(Roles = "admin")]
        public IActionResult GetCategoriesForSelection()
        {
            _logger.LogInformation(nameof(GetCategoriesForSelection));
            var result = _baseDAL.Get().Select(c => new CategoryGroupsViewModel(c));
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }

    }
}