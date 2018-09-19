using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Authorization.Models.ViewModels;
using WBS.DAL.Data.Interfaces;
using WBS.DAL.Layers.Interfaces;
using WBS.DAL.Layers;

namespace WBS.DAL.Authorization
{
    public class ExtensionDALIQueryableProfile : IExtensionDALIQueryable<User>
    {
        public IQueryable<User> GetItems(IQueryable<User> query)
        {
            return query.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
        }
    }

    public class ProfilesDAL: ICRUD<User>
    {
        ICRUD<User> _users_crud;
        ICRUD<UserRoles> _user_roles_crud;
        ICRUD<Role> _roles_crud;

        public ProfilesDAL(GetCRUD getcrud, ICRUD<UserRoles> users_roles_crud, ICRUD<Role> roles_crud)
        {
            _users_crud = getcrud(typeof(ProfilesDAL), typeof(User)) as ICRUD<User>;
            _user_roles_crud = users_roles_crud;
            _roles_crud = roles_crud;
        }

        public virtual User Get(string login, string password)
        {
            var hasher = new PasswordHasher<User>();
            return _users_crud.Get().AsQueryable()
            .Include(p => p.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefault(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase)
                && hasher.VerifyHashedPassword(p, p.Password, password) == PasswordVerificationResult.Success);
        }

        public virtual User GetByLogin(string login)
        {
                return _users_crud.Get().AsQueryable()
                .Where(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase))
                .Include(p => p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
        }

        public virtual User Add(UserRegisterViewModel userViewModel)
        {
            var user = InitFromRegisterViewModel(userViewModel, new User());
            var passwordHash = new PasswordHasher<User>().HashPassword(user, user.Password);
            user.Password = passwordHash;
            var userEntityEntry = _users_crud.Create(user);
            AddUsersRoles(user.Id, userViewModel.Roles);
            //userEntityEntry.Reload();
            return userEntityEntry;
        }

        public virtual User Remove(int id)
        {
            var result = _users_crud.Get(id);
            if (result != null)
            {
                _users_crud.Delete(id);
            }
            return result;
        }

        public virtual User MarkForDeletion(ProfileViewModel profile)
        {
            profile.DeletionMark = true;
            return UpdateUser(profile);
        }

        public virtual User Update(ProfileViewModel profileVM)
        {
            UpdateUserRoles(profileVM.Id, profileVM.Roles);
            return UpdateUser(profileVM);
        }

        public virtual User UpdateUser(ProfileViewModel profile)
        {
            //поскольку пришла вьюмодель, делаем замену на Пользователя перед добавлением в бд
            var user = _users_crud.Get().Where(p => p.Id == profile.Id).FirstOrDefault();
            if (user == null)
            {
                return user;
            }
            user = InitFromViewModel(profile, user);
            var entityEntry = _users_crud.Update(user);
            //entityEntry.Reload();
            var updated = Get(user.Id);
            return updated;
        }

        public virtual void UpdateUserRoles(int userId, List<RolesViewModel> roles)
        {
            //т.к связь мноие ко многим между Пользователем и Ролями реализована через вспомогательную сущность,
            //редактироване ролей пользователей осуществляется след. образом:
            //сначала удаляем записи из связующей таблицы с id пользователя,
            //затем добавлем новые пары (id-пользователя, id-роли)
            DeleteUsersRoles(userId);
            AddUsersRoles(userId, roles);
        }

        public virtual void DeleteUsersRoles(int userId)
        {
            var userRoles = _user_roles_crud.Get().Where(ur => ur.UserId == userId);
            if (userRoles.Count() != 0)
            {
                foreach(var ur in userRoles)
                {
                    _user_roles_crud.Delete(ur.Id);
                }
            }
        }

        public virtual void AddUsersRoles(int userId, List<RolesViewModel> roles)
        {
            var userRoles = new List<UserRoles>();
            foreach (var role in roles)
            {
                userRoles.Add(new UserRoles { UserId = userId, RoleId = role.Id });
            }
            foreach(var ur in userRoles)
            {
                _user_roles_crud.Create(ur);
            }
        }

        public virtual IEnumerable<Role> GetRoles()
        {
            return  _roles_crud.Get().OrderBy(item => item.Id).ToList();
        }

        public virtual User InitFromViewModel(ProfileViewModel viewModel, User user)
        {
            user.Fio = viewModel.Fio;
            user.JobPosition = viewModel.JobPosition;
            user.Department = viewModel.Department;
            user.DeletionMark = viewModel.DeletionMark;
            return user;
        }

        public virtual User InitFromRegisterViewModel(UserRegisterViewModel viewModel, User user)
        {
            user.Login = viewModel.Login;
            user.Password = viewModel.Password;
            user.Fio = viewModel.Fio;
            user.JobPosition = viewModel.JobPosition;
            user.Department = viewModel.Department;
            user.DeletionMark = viewModel.DeletionMark;
            return user;
        }

        public virtual bool IsAlreadyExistLogin(string login)
        {
            var user = _users_crud.Get().Where(p => p.Login.Equals(login)).FirstOrDefault();
            return user != null;
        }

        public User Update(User item)
        {
            return _users_crud.Update(item);
        }

        public User Delete(object id)
        {
            return _users_crud.Delete(id);
        }

        public User Create(User item)
        {
            return _users_crud.Create(item);
        }

        public IEnumerable<User> Get()
        {
            return _users_crud.Get();
        }

        public User Get(object id)
        {
            return _users_crud.Get(id);
        }
    }
}
