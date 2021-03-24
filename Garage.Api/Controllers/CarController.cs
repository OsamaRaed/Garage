using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Service.Services.CarService;
using Task3Garage.Service.Services.CarService;

namespace Garage.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICarService _CarService;
        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }

        [HttpGet]
        // GET: CarController

        public IActionResult Index()
        {
            var Cars = _CarService.Index();
            return Ok(GetRespons(Cars));
        }
        [HttpGet]
        // GET: CarController/Details/5

        public IActionResult Details(int id)
        {
            var Car = _CarService.Details(id);
            return Ok(GetRespons(Car));
        }
        [HttpPost]
        // POST: CarController/Create

        public IActionResult Create([FromBody] CreateCarDto dTO)
        {
            _CarService.Create(dTO);
            return Ok(GetRespons());
        }
        [HttpPut]
        // Put: CarController/Update

        public IActionResult Update([FromBody] UpdateCarDto dTO)
        {
            _CarService.Update(dTO);
            return Ok(GetRespons());
        }
        // Delete: CarController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _CarService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
