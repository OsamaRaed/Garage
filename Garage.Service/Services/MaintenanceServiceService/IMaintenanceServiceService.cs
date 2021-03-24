using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.MaintenanceServiceService
{
    public interface IMaintenanceServiceService
    {
        List<MaintenanceServiceVM> Index();
        MaintenanceServiceVM Details(int id);
        void Create(CreateMaintenanceServiceDto dTO);
        void Update(UpdateMaintenanceServiceDto dTO);
        void Delete(int id);
    }
}
