﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WBS.DAL;
using WBS.DAL.Cache;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Helpers
{
    public abstract class AbstractBaseTableController<T, U, V> : Controller where T : class, IBaseEntity where U : IViewModel<T> where V : class, ICRUD<T>
    {
        protected readonly ILogger _logger;
        protected readonly V _baseDAL;

        public AbstractBaseTableController(ICRUD<T> baseDAL, ILogger logger)
        {
            _baseDAL = baseDAL as V;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [Authorize]
        public virtual IActionResult Get(int id)
        {
            _logger.LogInformation("Getting information is started");

            var item = _baseDAL.Get(id);

            _logger.LogInformation("Getting information is completed");
            return Ok((U)Activator.CreateInstance(typeof(U), item));
        }

        /*[HttpGet("{currentPage}/{pageSize}")]
        [Authorize]
        public virtual IActionResult Get(int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Getting information is started");

            var allData = _baseDAL.Get()
                        .OrderBy(f => f.Id);
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(d => (U)Activator.CreateInstance(typeof(U), d))
                            .ToList();

            _logger.LogInformation("Getting information is completed");
            return Ok(new DataWithPaginationViewModel<U>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }*/
        
        //Обобщенный метод с учетом фильтрации и сортировки
        [HttpGet("{currentPage}/{pageSize}")]
        [Authorize]
        public virtual IActionResult Get(int currentPage = 0, int pageSize = 5, string filters = null, string sort = null) //as query params
        {
            _logger.LogInformation("Getting information is started");

            //TODO: реализовать необходимые преобразования, в зависимости от того, в каком виде данные придут с клиента
            //List<Filter> filtersList = ParseHelper.ParseFilters(filters);
            //Sort sortObj = ParseHelper.ParseSort(sort);

            List<Filter> filtersList = new List<Filter>();
            Sort sortObj = new Sort();
            var allData = _baseDAL.Get(filtersList, sortObj);
            
            var dataForPage = allData.Skip((currentPage) * pageSize)
                            .Take(pageSize)
                            .Select(d => (U)Activator.CreateInstance(typeof(U), d));

            _logger.LogInformation("Getting information is completed");

            return Ok(new DataWithPaginationViewModel<U>
            {
                Data = dataForPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = allData.Count() }
            });
        }

        [HttpPut]
        [Authorize]
        public virtual IActionResult Put([FromBody] U value)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (value == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }
            _logger.LogInformation("Change '{dataId}' data", value.Id);
            var updatedData = _baseDAL.Update(value.CreateModel());
            if (updatedData == null)
            {
                throw new Exception("Update is not successful");
            }
            _logger.LogInformation("Update is successful");
            return Ok((U)Activator.CreateInstance(typeof(U), updatedData));
        }

        [HttpPost]
        [Authorize]
        public virtual IActionResult Post([FromBody] U value)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (value == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }
            _logger.LogInformation("Create '{dataId}' data");
            var createdData = _baseDAL.Create(value.CreateModel());
            _logger.LogInformation("Create data (ID:{id}) is succussful", createdData.Id);
            var uri = new Uri($"{HttpContext.Request.Host}{HttpContext.Request.Path.Value}");
            return Created(uri, (U)Activator.CreateInstance(typeof(U), createdData));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public virtual IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Delete data, ID: {id} ", id);
            var result = _baseDAL.Delete(id);
            if (result != null)
            {
                _logger.LogInformation("Delete is successful");
                return Ok((U)Activator.CreateInstance(typeof(U), result));
            }
            else
            {
                string error = "Data cant be founded on this ID";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }
        }
    }
}
