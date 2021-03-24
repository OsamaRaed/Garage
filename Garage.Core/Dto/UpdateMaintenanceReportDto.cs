using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Dto
{
    public class UpdateMaintenanceReportDto
    {
        public int Id { get; set; }
        public int MaintenanceReportId { get; set; }
        public FormFile FilePath { get; set; }
    }

}
