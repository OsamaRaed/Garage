using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Service.Services.UserService;

namespace Garage.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        // GET: UserController

        public IActionResult Index()
        {
            var Users = _UserService.Index();
            return Ok(GetRespons(Users));
        }
        [HttpGet]
        // GET: UserController/Details/5

        public IActionResult Details(int id)
        {
            var User = _UserService.Details(id);
            return Ok(GetRespons(User));
        }
        [HttpPost]
        // POST: UserController/Create

        public IActionResult Create([FromBody] CreateUserDTO dTO)
        {
            _UserService.Create(dTO);
            return Ok(GetRespons());
        }
        [HttpPut]
        // Put: UserController/Update

        public IActionResult Update([FromBody] UpdateUserDTO dTO)
        {
            _UserService.Update(dTO);
            return Ok(GetRespons());
        }
        // Delete: UserController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _UserService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
