using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Dto
{
    public class CreateMaintenanceServiceDto
    {
        public int CarId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public IFormFile MaintenanceReport { get; set; }
    }
}
