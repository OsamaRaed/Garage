using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Garage.Service.Services.MaintenanceReportService
{
    public interface IMaintenanceReportService
    {
        Task<string> SaveFile(IFormFile file, string folderName);
        Task<string> SaveFile(string file, string folderName, string extension);
        Task<string> SaveFile(byte[] file, string folderName, string extension);
        Task<byte[]> GetFile(string folderName, string fileName);
    }
}
