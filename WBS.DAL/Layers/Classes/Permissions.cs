using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Layers.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WBS.DAL.Exceptions;
using WBS.DAL.Cache;
using WBS.DAL.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace WBS.DAL.Layers.Classes
{
    public class Permissions<T> : IPermissions<T> where T: class, IBaseEntity
    {
        ICRUD<T> _crud;
        private bool _allowGet, _allowCreate, _allowDelete, _allowUpdate;
        private ILogger _logger;

        public Permissions(GetCRUD getcrud, IHttpContextAccessor context, IPermissionsDAL permissionsDal, ILogger<Permissions<T>> logger)
        {
            _crud = getcrud(typeof(IPermissions<>), typeof(T)) as ICRUD<T>;
            _logger = logger;
            try
            {
                var roles = context.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
                var permissions = permissionsDal.GetPermissionsForType(
                    typeof(T).FullName, 
                    typeof(T).Assembly.GetName().Name, 
                    roles);
                _allowCreate = permissions.Any(p => p.AllowCreate);
                _allowDelete = permissions.Any(p => p.AllowDelete);
                _allowGet = permissions.Any(p => p.AllowRead);
                _allowUpdate = permissions.Any(p => p.AllowWrite);
            }
            catch
            {
                _logger.LogInformation("Ошибка получения ролей текущего пользователя");
            }
        }

        public T Create(T item)
        {
            if (_allowCreate)
                return _crud.Create(item);
            else
                throw new NoPermissionsException("У пользователя отсутствует право на создание");
        }

        public T Delete(object id)
        {
            if (_allowDelete)
                return _crud.Delete(id);
            else
                throw new NoPermissionsException("У пользователя отсутствует право на удаление");
        }

        public IEnumerable<T> Get()
        {
            if (_allowGet)
                return _crud.Get();
            else
                throw new NoPermissionsException("У пользователя отсутствует право на чтение");
        }

        public T Get(object id)
        {
            if (_allowGet)
                return _crud.Get(id);
            else
                throw new NoPermissionsException("У пользователя отсутствует право на чтение");
        }

        public T Update(T item)
        {
            if (_allowUpdate)
                return _crud.Update(item);
            else
                throw new NoPermissionsException("У пользователя отсутствует право на запись");
        }
    }
}
