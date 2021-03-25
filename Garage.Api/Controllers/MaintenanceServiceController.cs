using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Service.Services.MaintenanceServiceService;

namespace Garage.Controllers
{
    public class MaintenanceServiceController : BaseController
    {
        private readonly IMaintenanceServiceService _MaintenanceServiceService;
        public MaintenanceServiceController(IMaintenanceServiceService MaintenanceServiceService)
        {
            _MaintenanceServiceService = MaintenanceServiceService;
        }

        [HttpGet]
        // GET: MaintenanceServiceController

        public IActionResult Index(int page)
        {
            var MaintenanceServices = _MaintenanceServiceService.Index(page);
            return Ok(GetRespons(MaintenanceServices));
        }
        [HttpGet]
        // GET: MaintenanceServiceController/Details/5

        public IActionResult Details(int id)
        {
            var MaintenanceService = _MaintenanceServiceService.Details(id);
            return Ok(GetRespons(MaintenanceService));
        }
        [HttpPost]
        // POST: MaintenanceServiceController/Create

        public IActionResult Create([FromForm] CreateMaintenanceServiceDto dTO)
        {
            _MaintenanceServiceService.Create(dTO);
            return Ok(GetRespons());
        }
        [HttpPut]
        // Put: MaintenanceServiceController/Update

        public IActionResult Update([FromForm] UpdateMaintenanceServiceDto dTO)
        {
            _MaintenanceServiceService.Update(dTO);
            return Ok(GetRespons());
        }
        // Delete: MaintenanceServiceController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _MaintenanceServiceService.Delete(id);
            return Ok(GetRespons());
        }

    }
}
