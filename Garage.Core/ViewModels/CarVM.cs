using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModels
{
    public class CarVM
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public List<MaintenanceServiceVM> MaintenanceServices { get; set; }
    }
}
