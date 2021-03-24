using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.EmployeeService
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
