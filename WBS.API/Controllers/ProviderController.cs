using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Data.Models;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProviderController : AbstractBaseTableController<Provider, ProviderViewModel, ProviderDAL>
    {
        public ProviderController(ICRUD<Provider> baseDAL, ILogger<ProviderController> logger) : base(baseDAL, logger)
        {
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Get provider, ID: '{id}", id);
            return Ok(_baseDAL.Get(id));
        }

        [HttpGet("{title}/{currentPage}/{pageSize}")]
        [Authorize]
        public IActionResult Get(int currentPage = 0, int pageSize = 5, string title = "", string techServs ="")
        {
            _logger.LogInformation("Getting information is started");
            var data = _baseDAL.Get();
            if(!String.IsNullOrEmpty(title))
            {
                data = data.Where(q => q.Title.Contains(title));
            }

            if (!String.IsNullOrEmpty(techServs))
            {
                var techServsIds = techServs.Split(",")
                    .Select( x =>
                    {
                        Int32.TryParse(x, out int b);
                        return b;
                    }).ToList();

                if (techServsIds != null)
                {
                    var providersIds = _baseDAL.Get().Where(pts => techServsIds.FirstOrDefault(t => t == pts.Id) != 0).GroupBy(pts => pts.Id).Select(el => el.Key);
                    data = data.Where(provider => providersIds.FirstOrDefault(el => el == provider.Id) != 0);
                }

            }

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<ProviderViewModel>
            {
                Data = data
                        .Select(d => new ProviderViewModel(d))
                        .OrderBy(f => f.Id)
                        .Skip((currentPage) * pageSize)
                        .Take(pageSize),
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = data.Count() }
            });
        }
    }
}
