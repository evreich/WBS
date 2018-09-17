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
using System.Linq.Dynamic.Core;
using WBS.DAL.Data.Helpers;

namespace WBS.DAL.Layers.Classes
{
    public class Permissions<T> : IPermissions<T> where T: class, IBaseEntity
    {
        ICRUD<T> _crud;
        private bool _allowGet, _allowCreate, _allowDelete, _allowUpdate;
        private ILogger _logger;
        private List<ExpressionCheck> _typeExpressions = new List<ExpressionCheck>();
        private IPermissionsDAL permissionsDal;

        public Permissions(GetCRUD getcrud, IHttpContextAccessor context, IPermissionsDAL _permissionsDal, ILogger<Permissions<T>> logger)
        {
            _crud = getcrud(typeof(IPermissions<>), typeof(T)) as ICRUD<T>;
            _logger = logger;
            permissionsDal = _permissionsDal;

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

                //все критерии для переданного типа
                var typeCriterions = permissionsDal.GetTypeCriterions(typeof(T).FullName, typeof(T).Assembly.GetName().Name);
                foreach (var crit in typeCriterions)
                {
                    var exp = DynamicExpressionParser.ParseLambda(typeof(T), typeof(bool), crit.Criteria, null);
                    var _del = exp.Compile();
                    _typeExpressions.Add(new ExpressionCheck{ExpressionDel = _del, AllowCreate = crit.AllowCreate, AllowDelete = crit.AllowDelete, AllowRead = crit.AllowRead, AllowWrite = crit.AllowWrite});
                }
            }
            catch
            {
                _logger.LogInformation("Ошибка получения ролей текущего пользователя");
            }
        }

        public T Create(T item)
        {
            if (_allowCreate)
            {
                return _crud.Create(item);
            }
            else
            {
                var expressionDelegates = _typeExpressions.Where(exp => exp.AllowCreate).Select(exp => exp.ExpressionDel);
                if (expressionDelegates.Any() && permissionsDal.CheckCriterions<T>(item, expressionDelegates))
                {
                    return _crud.Create(item);
                    //throw new NoPermissionsException("С объектом в текущем состоянии нельзя выполнить данную операцию");
                }
            }
            throw new NoPermissionsException("У пользователя отсутствует право на создание");
        }

        public T Delete(object id)
        {
            if (_allowDelete)
            {
                return _crud.Delete(id);
            }
            else
            {
                var expressionDelegates = _typeExpressions.Where(exp => exp.AllowDelete).Select(exp => exp.ExpressionDel);
                var item = _crud.Get(id);
                if (expressionDelegates.Any() && permissionsDal.CheckCriterions<T>(item, expressionDelegates))
                {
                    return _crud.Delete(id);
                }
            }

            throw new NoPermissionsException("У пользователя отсутствует право на удаление");
        }

        public IEnumerable<T> Get()
        {
            if (_allowGet)
            {
                return _crud.Get();
            }
            else
            {
                var expressionDelegates = _typeExpressions.Where(exp => exp.AllowRead).Select(exp => exp.ExpressionDel);
                if (expressionDelegates.Any())
                {
                    return _crud.Get().Where(item => permissionsDal.CheckCriterions<T>(item, expressionDelegates));
                }
            }
            throw new NoPermissionsException("У пользователя отсутствует право на чтение");
        }

        public T Get(object id)
        {
            if (_allowGet)
            {
                var item = _crud.Get(id);
                return item;
            }
            else
            {
                var expressionDelegates = _typeExpressions.Where(exp => exp.AllowRead).Select(exp => exp.ExpressionDel);
                var item = _crud.Get(id);
                if (expressionDelegates.Any() && permissionsDal.CheckCriterions<T>(item, expressionDelegates))
                {
                    return item;
                }
            }

            throw new NoPermissionsException("У пользователя отсутствует право на чтение");
        }

        public T Update(T item)
        {
            if (_allowUpdate)
            {
                return _crud.Update(item);
            }
            else
            {
                var expressionDelegates = _typeExpressions.Where(exp => exp.AllowWrite).Select(exp => exp.ExpressionDel);
                if (expressionDelegates.Any() && permissionsDal.CheckCriterions<T>(item, expressionDelegates))
                {
                    return _crud.Update(item);
                }
            }

            throw new NoPermissionsException("У пользователя отсутствует право на запись");
        }
    }
}
