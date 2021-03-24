using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModels
{
    public class EmployeeVM
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        public List<MaintenanceServiceVM> MaintenanceServices { get; set; }
    }
}
