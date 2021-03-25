using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Service.Services.CustomerService;

namespace Garage.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [HttpGet]
        // GET: CustomerController

        public IActionResult Index(int page)
        {
            var Customers = _CustomerService.Index(page);
            return Ok(GetRespons(Customers));
        }
        [HttpGet]
        // GET: CustomerController/Details/5

        public IActionResult Details(int id)
        {
            var Customer = _CustomerService.Details(id);
            return Ok(GetRespons(Customer));
        }
        [HttpPost]
        // POST: CustomerController/Create

        public IActionResult Create([FromBody] CreateCustomerDto dTO)
        {
            _CustomerService.Create(dTO);
            return Ok(GetRespons());
        }
        [HttpPut]
        // Put: CustomerController/Update

        public IActionResult Update([FromBody] UpdateCustomerDto dTO)
        {
            _CustomerService.Update(dTO);
            return Ok(GetRespons());
        }
        // Delete: CustomerController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _CustomerService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
