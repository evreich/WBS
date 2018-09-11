using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Data.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PermissionsController : Controller
    {
        private readonly IPermissionsDAL _permissionsDAL;
        public PermissionsController(IPermissionsDAL permissionsDAL)
        {
            _permissionsDAL = permissionsDAL;
        }

        [HttpGet("menu")]
        public IEnumerable<MenuItem> GetMenuItems([FromServices] IHttpContextAccessor context)
        {
            var roles = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            var menuItems = _permissionsDAL.GetPermissionsForMenuItems(roles);
            var lookup = menuItems.ToLookup(mi => mi.ParentId);
            List<MenuItem> build(int? parentId) => lookup[parentId]
            .Select(x => new MenuItem()
            {
                Id = x.Id,
                Text = x.Text,
                To = x.To,
                IconName = x.IconName,
                Children = build(x.Id)
            })
            .ToList();
            var result = build(null);
            return result;
        }
    }
}
