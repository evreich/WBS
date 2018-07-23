using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using WBS.DAL.Authorization.Models;
using WBS.DAL.Cache;

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
        public User Get(string login, string password)
        {
            return _cache.Get(login, param =>
            {
                var hasher = new PasswordHasher<User>();
                return _context.Profiles
                .Include(_p => _p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(p => p.Login.Equals(login, StringComparison.InvariantCultureIgnoreCase)
                    && hasher.VerifyHashedPassword(p, p.Password, password) == PasswordVerificationResult.Success);
            });
        }

        public User GetById(int id)
        {
            return _cache.Get(id, param =>
            {
                return _context.Profiles
                .Where(p => p.Id == id)
                .Include(_p => _p.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault();         
            });
        }

        public IEnumerable<User> GetUsers()
        {
            return _cache.Get<IEnumerable<User>>(_cache.AllIdentifier,
            param => _context.Profiles
                                .Include(_p => _p.UserRoles)
                                   .ThenInclude(ur => ur.Role)
                                .OrderBy(item => item.Id).ToList());
        }

        public User Add(UserRegisterViewModel userViewModel)
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

        public User Remove(int id)
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

        public User MarkForDeletion(ProfileViewModel profile)
        {
            profile.DeletionMark = true;
            return UpdateUser(profile);
        }

        public User Update(ProfileViewModel profileVM)
        {
            UpdateUserRoles(profileVM.Id, profileVM.Roles);
            return UpdateUser(profileVM);
        }

        public User UpdateUser(ProfileViewModel profile)
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

        public void UpdateUserRoles(int userId, List<RolesViewModel> roles)
        {
            //т.к связь мноие ко многим между Пользователем и Ролями реализована через вспомогательную сущность,
            //редактироване ролей пользователей осуществляется след. образом:
            //сначала удаляем записи из связующей таблицы с id пользователя,
            //затем добавлем новые пары (id-пользователя, id-роли)
            DeleteUsersRoles(userId);
            AddUsersRoles(userId, roles);
        }

        public void DeleteUsersRoles(int userId)
        {
            var userRoles = _context.UserRoles.Where(u => u.UserId == userId).ToList();
            if (userRoles.Count() != 0)
            {
                _context.RemoveRange(userRoles);
                _context.SaveChanges();
            }
        }

        public void AddUsersRoles(int userId, List<RolesViewModel> roles)
        {
            var userRoles = new List<UserRoles>();
            foreach (var role in roles)
            {
                userRoles.Add(new UserRoles { UserId = userId, RoleId = role.Id });
            }
            _context.AddRange(userRoles);
            _context.SaveChanges();
        }

        public IEnumerable<Role> GetRoles()
        {
            return _cache.Get<IEnumerable<Role>>(_cache.AllIdentifier,
                param => _context.Roles.OrderBy(item => item.Id).ToList());
        }

        public User InitFromViewModel(ProfileViewModel viewModel, User user)
        {
            user.Fio = viewModel.Fio;
            user.JobPosition = viewModel.JobPosition;
            user.Department = viewModel.Department;
            user.DeletionMark = viewModel.DeletionMark;
            return user;
        }

        public User InitFromRegisterViewModel(UserRegisterViewModel viewModel, User user)
        {
            user.Login = viewModel.Login;
            user.Password = viewModel.Password;
            user.Fio = viewModel.Fio;
            user.JobPosition = viewModel.JobPosition;
            user.Department = viewModel.Department;
            user.DeletionMark = viewModel.DeletionMark;
            return user;
        }

        public bool IsAlreadyExistLogin (string login)
        {
            var user = _context.Profiles.Where(p => p.Login.Equals(login)).FirstOrDefault();
            return user != null;
        }
    }
}
