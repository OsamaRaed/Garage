using Garage.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Api.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return Redirect("/Swagger");
        }
    }

}
