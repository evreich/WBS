using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;
using WBS.DAL.Authorization.Models.ViewModels;

namespace WBS.DAL.Authorization
{
    public class ProfilesDAL
    {
        readonly WBSContext _context;
        readonly ICache _cache;

        public ProfilesDAL(WBSContext context, ICache cache)
        {
            _cache = cache;
            _context = context;
        }

        public virtual User Get(string login, string password)
        {
            return _cache.Get(login, param =>
            {
                var hasher = new PasswordHasher<User>();
                return _context.Profiles
                .Include(p => p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase)
                    && hasher.VerifyHashedPassword(p, p.Password, password) == PasswordVerificationResult.Success);
            });
        }

        public virtual User GetById(int id)
        {
            return _cache.Get(id, param =>
            {
                return _context.Profiles
                .Where(p => p.Id == id)
                .Include(p => p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
            });
        }

        public virtual User GetByLogin(string login)
        {
            return _cache.Get(login, param =>
            {
                return _context.Profiles
                .Where(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase))
                .Include(p => p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault();
            });
        }

        public virtual IEnumerable<User> GetUsers()
        {
            return _cache.Get<IEnumerable<User>>(_cache.AllIdentifier,
            param => _context.Profiles
                                .Include(p => p.UserRoles)
                                   .ThenInclude(ur => ur.Role)
                                .OrderBy(item => item.Id).ToList());
        }

        public virtual User Add(UserRegisterViewModel userViewModel)
        {
            var user = InitFromRegisterViewModel(userViewModel, new User());
            var passwordHash = new PasswordHasher<User>().HashPassword(user, user.Password);
            user.Password = passwordHash;
            var userEntityEntry = _context.Profiles.Add(user);
            _context.SaveChanges();
            AddUsersRoles(user.Id, userViewModel.Roles);
            userEntityEntry.Reload();
            _cache.Add(user.Login, userEntityEntry.Entity);
            return userEntityEntry.Entity;
        }

        public virtual User Remove(int id)
        {
            var result = _context.Profiles.Where(p => p.Id == id).FirstOrDefault();
            if (result != null)
            {
                _context.Profiles.Remove(result);
                _context.SaveChanges();
                _cache.Remove(result);
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
            var user = _context.Profiles.Where(p => p.Id == profile.Id).FirstOrDefault();
            if (user == null)
            {
                return user;
            }
            user = InitFromViewModel(profile, user);
            var entityEntry = _context.Profiles.Update(user);
            _context.SaveChanges();
            entityEntry.Reload();
            _cache.Add(user.Login, entityEntry.Entity);
            var updated = GetById(user.Id);
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
            var userRoles = _context.UserRoles.Where(u => u.UserId == userId).ToList();
            if (userRoles.Count() != 0)
            {
                _context.RemoveRange(userRoles);
                _context.SaveChanges();
            }
        }

        public virtual void AddUsersRoles(int userId, List<RolesViewModel> roles)
        {
            var userRoles = new List<UserRoles>();
            foreach (var role in roles)
            {
                userRoles.Add(new UserRoles { UserId = userId, RoleId = role.Id });
            }
            _context.AddRange(userRoles);
            _context.SaveChanges();
        }

        public virtual IEnumerable<Role> GetRoles()
        {
            return _cache.Get<IEnumerable<Role>>(_cache.AllIdentifier,
                param => _context.Roles.OrderBy(item => item.Id).ToList());
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
            var user = _context.Profiles.Where(p => p.Login.Equals(login)).FirstOrDefault();
            return user != null;
        }
    }
}
