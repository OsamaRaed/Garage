using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModels
{
    public class MaintenanceServiceVM
    {
        public CarVM Car { get; set; }
        public EmployeeVM Employee { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public MaintenanceReportVM MaintenanceReport { get; set; }
    }
}
