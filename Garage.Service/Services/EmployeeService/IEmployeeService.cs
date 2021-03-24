using System;
using System.Collections.Generic;
using System.Text;
using Task3Garage.Core.Dto;
using Task3Garage.Core.ViewModels;

namespace Task3Garage.Service.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeVM> Index();
        EmployeeVM Details(int id);
        void Create(CreateEmployeeDto Dto);
        void Update(UpdateEmployeeDto Dto);
        void Delete(int id);
    }
}
