using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.MaintenanceServiceService
{
    public interface IMaintenanceServiceService
    {
        PagingVM Index(int page);
        MaintenanceServiceVM Details(int id);
        Task Create(CreateMaintenanceServiceDto dTO);
        void Update(UpdateMaintenanceServiceDto dTO);
        void Delete(int id);
    }
}
