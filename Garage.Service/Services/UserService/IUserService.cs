using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;

namespace Garage.Service.Services.UserService
{
    public interface IUserService
    {
        List<UserVM> Index();
        UserVM Details(string id);
        Task<bool> CreateAsync(CreateUserDTO dTO);
        Task UpdateAsync(UpdateUserDTO dTO);
        void Delete(string id);
    }
}
