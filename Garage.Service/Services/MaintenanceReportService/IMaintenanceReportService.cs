using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.MaintenanceReportService
{
    public interface IMaintenanceReportService
    {
        List<MaintenanceReportVM> Index();
        MaintenanceReportVM Details(int id);
        void Create(CreateMaintenanceReportDto dTO);
        void Update(UpdateMaintenanceReportDto dTO);
        void Delete(int id);
    }
}
