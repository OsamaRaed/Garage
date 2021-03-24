using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;

namespace Garage.Service.Services.UserService
{
    public interface IUserService
    {
        List<UserVM> Index();
        UserVM Details(int id);
        void Create(CreateUserDTO dTO);
        void Update(UpdateUserDTO dTO);
        void Delete(int id);
    }
}
