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
    public class CategoriesOfEquipmentController : AbstractBaseTableController<CategoryOfEquipment, CategoriesOfEquipmentViewModel, CategoriesOfEquipmentDAL>
    {
        public CategoriesOfEquipmentController(ICRUD<CategoryOfEquipment> baseDAL, ILogger<CategoriesOfEquipmentController> logger) 
            : base(baseDAL, logger)
        {
        }


        [HttpGet("categoriesOfEquipSelection")]
        [Authorize(Roles = "Администратор")]
        public IActionResult GetCategoriesOfEquipForSelection()
        {
            _logger.LogInformation(nameof(GetCategoriesOfEquipForSelection));
            var result = _baseDAL.Get().Select(c => new CategoriesOfEquipmentViewModel(c));
            _logger.LogInformation("Getting information is succesful");
            return Ok(result);
        }
    }
}