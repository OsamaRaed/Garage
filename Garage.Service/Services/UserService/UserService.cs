using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Api.Data;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;
using Garage.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Garage.Service.Services.UserService
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _DB;
        private UserManager<UserDbEntity> _userManager;

        public UserService(ApplicationDbContext DB, UserManager<UserDbEntity> userManager)
        {
            _DB = DB;
            _userManager = userManager;
        }

        public List<UserVM> Index()

        {
            var users = _DB.Users.Where(x => !x.IsDelete).Select(x => new UserVM()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                DOB = x.DOB
            }).ToList();

            return users;

        }

        public UserVM Details(string id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            var uservm = new UserVM()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                DOB = user.DOB
            };
            return uservm;

        }

        public async Task<bool> CreateAsync(CreateUserDTO dto)
        {
            var user = new UserDbEntity();
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.DOB = dto.DOB;
            user.CreatedAt = DateTime.Now;
            user.UserName = dto.PhoneNumber;
            user.IsDelete = false;

            var result = await _userManager.CreateAsync(user, "Osama11$$");

            return result.Succeeded;

        }

        public async Task UpdateAsync(UpdateUserDTO dto)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.DOB = dto.DOB;
            user.UpdatedAt = DateTime.Now;

            await _userManager.UpdateAsync(user);

        }

        public void Delete(string id)
        {
            var user = _DB.Users.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            user.IsDelete = true;
            _DB.Users.Update(user);
            _DB.SaveChanges();
        }


    }
}
