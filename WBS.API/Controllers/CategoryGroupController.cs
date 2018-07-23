using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WBS.DAL;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Models;
using WBS.DAL.Data.Models;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;

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