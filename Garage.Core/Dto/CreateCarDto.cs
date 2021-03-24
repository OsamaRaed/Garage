using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Dto

{
    public class CreateCarDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int CustomerId { get; set; }
        public List<int> MaintenanceService { get; set; }
    }
}
