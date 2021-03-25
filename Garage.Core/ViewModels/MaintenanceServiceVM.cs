using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModels
{
    public class MaintenanceServiceVM
    {
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public MaintenanceReportVM MaintenanceReport { get; set; }
        public CarVM Car { get; set; }
    }
}
