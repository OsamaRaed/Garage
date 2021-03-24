using Microsoft.AspNetCore.Http;

namespace Garage.Core.Dto
{
    public class UpdateMaintenanceReportDto
    {
        public int Id { get; set; }
        public int MaintenanceReportId { get; set; }
        public IFormFile FilePath { get; set; }
    }

}
