using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Dto
{
    public class CreateMaintenanceReportDto
    {
        public int MaintenanceReportId { get; set; }
        public IFormFile FilePath { get; set; }
    }

}
