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

        public IActionResult Details(string id)
        {
            var User = _UserService.Details(id);
            return Ok(GetRespons(User));
        }
        [HttpPost]
        // POST: UserController/Create

        public IActionResult Create([FromBody] CreateUserDTO dTO)
        { 
              return Ok(GetRespons(_UserService.CreateAsync(dTO)));
        }
        [HttpPut]
        // Put: UserController/Update

        public IActionResult Update([FromBody] UpdateUserDTO dTO)
        {
            _UserService.UpdateAsync(dTO);
            return Ok(GetRespons());
        }
        // Delete: UserController/Delete/5
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            _UserService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
