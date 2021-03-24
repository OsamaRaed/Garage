using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Service.Services.EmployeeService;

namespace Garage.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        // GET: EmployeeController

        public IActionResult Index()
        {
            var Employees = _EmployeeService.Index();
            return Ok(GetRespons(Employees));
        }
        [HttpGet]
        // GET: EmployeeController/Details/5

        public IActionResult Details(int id)
        {
            var Employee = _EmployeeService.Details(id);
            return Ok(GetRespons(Employee));
        }
        [HttpPost]
        // POST: EmployeeController/Create

        public IActionResult Create([FromBody] CreateEmployeeDto dTO)
        {
            _EmployeeService.Create(dTO);
            return Ok(GetRespons());
        }
        [HttpPut]
        // Put: EmployeeController/Update

        public IActionResult Update([FromBody] UpdateEmployeeDto dTO)
        {
            _EmployeeService.Update(dTO);
            return Ok(GetRespons());
        }
        // Delete: EmployeeController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _EmployeeService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
