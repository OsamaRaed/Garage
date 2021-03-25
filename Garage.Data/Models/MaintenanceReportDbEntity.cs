using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data.Models
{
    public class MaintenanceReportDbEntity : BaseEntity
    {
        public MaintenanceServiceDbEntity MaintenanceService { get; set; }
        public int MaintenanceServiceId { get; set; }
        public string FilePath { get; set; }
    }
}
