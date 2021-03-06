﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WBS.API.Helpers;
using WBS.DAL;
using WBS.DAL.Authorization;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Authorization.Models.ViewModels;
using WBS.DAL.Data.Helpers;
using WBS.DAL.Data.Models.ModelsForSelections;
using WBS.DAL.Data.Models.ViewModels;
using WBS.DAL.Layers.Interfaces;

namespace WBS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Roles = "Администратор")]
    public class ProfileController : Controller
    {
        private readonly IServiceProvider _provider;
        private readonly ProfilesDAL _dal;
        private readonly ILogger<ProfileController> _logger;
        private readonly ICRUD<User> _users_crud;

        public ProfileController(ICRUD<User> users_crud, IServiceProvider provider, ProfilesDAL dal, ILogger<ProfileController> logger)
        {
            _provider = provider;
            _dal = dal;
            _logger = logger;
            _users_crud = users_crud;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserRegisterViewModel user)
        {
            //add model validator filters, add ModelState.IsValid and throw BadRequest(ModelState)
            if (user == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }

            if (_dal.IsAlreadyExistLogin(user.Login))
            {
                var error = "Логин занят";
                _logger.LogInformation(error);
                return BadRequest(new ResponseError(error));
            }

            _logger.LogInformation("Add '{userTitle}' user", user.Login);
            var createdData = _dal.Add(user);
            _logger.LogInformation("Create is succussful");
            return Ok(new ProfileViewModel(createdData));
        }

        [HttpPut("markForDeletion")]
        public IActionResult MarkForDeletion([FromBody]ProfileViewModel user)
        {
            if (user == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }

            _logger.LogInformation("Marking for deletion '{formatTitle}' user is started", user.Fio);
            //не удаляем из базы, а ставим пометку на удаление
            var result = _dal.MarkForDeletion(user);
            if (result == null)
            {
                string error = "Marking cant be completed on this user";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }

            _logger.LogInformation("Marking is succussful");

            return Ok(new ProfileViewModel(result));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Delete profile, ID: {id} ", id);
            var result = _dal.Remove(id);
            if (result != null)
            {
                _logger.LogInformation("Delete is successful");
                return Ok(new ProfileViewModel(result));
            }
            else
            {
                string error = "Profile cant be founded on this ID";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProfileViewModel user)
        {
            if (user == null)
            {
                var error = "Arguments of request is null";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }
            _logger.LogInformation("Update profile of user '{login}'", user.Fio);
            var result = _dal.Update(user);
            if (result != null)
            {
                _logger.LogInformation("Update is successful");
                return Ok(new ProfileViewModel(result));
            }
            else
            {
                string error = "Profile cant be founded on this ID (in DB or Cache)";
                _logger.LogInformation(error);
                return BadRequest(new { error });
            }
        }


        [HttpGet("{currentPage}/{pageSize}")]
        public IActionResult Get(int currentPage = 0, int pageSize = 5)
        {
            _logger.LogInformation("Get information about profiles on page");
            var data = _users_crud.Get()
                        .Select(u => new ProfileViewModel(u))
                        .ToList();
            var dataToPage = data.OrderBy(f => f.Id)
                            .Skip((currentPage) * pageSize)
                            .Take(pageSize);
            _logger.LogInformation("Getting information is succesfull");
            return Ok(new DataWithPaginationViewModel<ProfileViewModel>
            {
                Data = dataToPage,
                Pagination = new Pagination { CurrentPage = currentPage, ElementsPerPage = pageSize, ElementsCount = data.Count() }
            });
        }

        [HttpGet("rolesSelection")]
        public IActionResult GetRolessForSelection()
        {
            _logger.LogInformation(nameof(GetRolessForSelection));
            var result = _dal.GetRoles().Select(r => new RolesViewModel(r)).ToList();
            _logger.LogInformation("Getting roles is successful");
            return Ok(result);
        }

        [HttpGet("usersSelection")]
        public IActionResult GetProfilesForSelection(string query = "", int? count = null)
        {
            _logger.LogInformation(nameof(GetProfilesForSelection));
            //выбираем только тех пользователей, у которых нет пометки на удаление
            var result = _users_crud.Get()
                .Where(p => !p.DeletionMark
                       && (string.IsNullOrEmpty(query) ||
                          (!string.IsNullOrEmpty(p.Fio) && p.Fio.ToUpper().Contains(query.ToUpper())
                           || !string.IsNullOrEmpty(p.Login) && p.Login.ToUpper().Contains(query.ToUpper()))))                          
                .Select(f => new ProfilesForSelection(f));
                
            if (count.HasValue)
            {
                result = result.Take(count.GetValueOrDefault()).ToList();
            }
            _logger.LogInformation("Getting profiles is successful");
            return Ok(result);
        }
    }
}

