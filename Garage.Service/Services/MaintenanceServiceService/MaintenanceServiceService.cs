using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Api.Data;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;
using Garage.Data.Models;
using Garage.Service.Services.MaintenanceReportService;
using Microsoft.EntityFrameworkCore;

namespace Garage.Service.Services.MaintenanceServiceService
{
    public class MaintenanceServiceService : IMaintenanceServiceService
    {
        private readonly ApplicationDbContext _DB;
        private IMaintenanceReportService _MaintenanceReportService;
        public MaintenanceServiceService(ApplicationDbContext DB, IMaintenanceReportService MaintenanceReportService)
        {
            _DB = DB;
            _MaintenanceReportService = MaintenanceReportService;
        }

        public PagingVM Index(int page)
        {
            var pages = Math.Ceiling(_DB.MaintenanceServices.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;
            var MaintenanceServices = _DB.MaintenanceServices.Include(x => x.MaintenanceReport).Include(x => x.Car)
                .Select(x => new MaintenanceServiceVM()
                {
                    EntryDate = x.EntryDate,
                    ExitDate = x.ExitDate,
                    MaintenanceReport = new MaintenanceReportVM()
                    {
                        FilePath = x.MaintenanceReport.FilePath
                    },
                    
                    
                }).Skip(skip).Take(10).ToList();
            var paging = new PagingVM()
            {
                Data = MaintenanceServices,
                NumberOfPages = (int)pages,
                CureentPage = page
            };
            return paging;
        }

        public MaintenanceServiceVM Details(int id)
        {
            var MaintenanceService = _DB.MaintenanceServices.Include(x => x.MaintenanceReport)
                 .SingleOrDefault(x => x.Id == id);
            return new MaintenanceServiceVM()
            {
                EntryDate = MaintenanceService.EntryDate,
                ExitDate = MaintenanceService.ExitDate,
                MaintenanceReport = new MaintenanceReportVM()
                {
                    FilePath = MaintenanceService.MaintenanceReport.FilePath
                }
            };
        }

        public async Task Create(CreateMaintenanceServiceDto dto)
        {
            var MaintenanceService = new MaintenanceServiceDbEntity()
            {
                EmployeeId = dto.EmployeeId,
                EntryDate = dto.EntryDate,
                ExitDate = dto.ExitDate,
                CarId = dto.CarId
            };
            _DB.MaintenanceServices.Add(MaintenanceService);
            _DB.SaveChanges();
            var report = await _MaintenanceReportService.SaveFile(dto.MaintenanceReport, "MaintenanceReports");
            var MaintenanceReport = new MaintenanceReportDbEntity()
            {
                FilePath = report,
                MaintenanceServiceId = MaintenanceService.Id
            };
            _DB.MaintenanceReports.Add(MaintenanceReport);
            _DB.SaveChanges();
        }

        public void Update(UpdateMaintenanceServiceDto dto)
        {
            var MaintenanceService = _DB.MaintenanceServices.SingleOrDefault(x => x.Id == dto.Id && !x.IsDelete);
            MaintenanceService.EmployeeId = dto.EmployeeId;
            MaintenanceService.EntryDate = dto.EntryDate;
            MaintenanceService.ExitDate = dto.ExitDate;
            _DB.MaintenanceServices.Update(MaintenanceService);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var MaintenanceService = _DB.MaintenanceServices.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            MaintenanceService.IsDelete = true;
            _DB.MaintenanceServices.Update(MaintenanceService);
            _DB.SaveChanges();
        }
    }
}
