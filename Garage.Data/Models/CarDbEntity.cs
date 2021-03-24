using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data.Models
{
    public class CarDbEntity : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int CustomerId { get; set; }
        public CustomerDbEntity Customer { get; set; }
        public List<MaintenanceServiceDbEntity> MaintenanceService{ get; set; }
    }
}
