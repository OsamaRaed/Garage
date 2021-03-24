using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Data.Models
{
    public class MaintenanceServiceDbEntity : BaseEntity
    {
        public int CarId { get; set; }
        public CarDbEntity Car { get; set; }
        public EmployeeDbEntity Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public MaintenanceReportDbEntity MaintenanceReport { get; set; }
        public int MaintenanceReportId { get; set; }
    }
}
