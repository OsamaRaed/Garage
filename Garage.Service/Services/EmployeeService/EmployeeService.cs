using System;
using System.Collections.Generic;
using System.Text;
using Garage.Data;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Api.Data;
using System.Linq;
using Garage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _DB;

        public EmployeeService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public PagingVM Index(int page)

        {
            var pages = Math.Ceiling(_DB.Employees.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;
            var Employees = _DB.Employees.Include(x => x.MaintenanceServices)
                .Select(x => new EmployeeVM()
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    Address = x.Address,
                    Salary = x.Salary,
                    MaintenanceServices = x.MaintenanceServices
                    .Select(y => new MaintenanceServiceVM()
                    {
                        EntryDate = y.EntryDate,
                        ExitDate = y.ExitDate
                    }).ToList()
                }).Skip(skip).Take(10).ToList();
            var paging = new PagingVM()
            {
                Data = Employees,
                NumberOfPages = (int)pages,
                CureentPage = page
            };
            return paging;
        }

        public EmployeeVM Details(int id)
        {
            var Employee = _DB.Employees.Include(x => x.MaintenanceServices)
                .SingleOrDefault(x => x.Id == id);
            return new EmployeeVM()
            {
                Name = Employee.Name,
                Phone = Employee.Phone,
                Address = Employee.Address,
                Salary = Employee.Salary,
                EmploymentDate = Employee.EmploymentDate,
                MaintenanceServices = Employee.MaintenanceServices
                    .Select(y => new MaintenanceServiceVM()
                    {
                        EntryDate = y.EntryDate,
                        ExitDate = y.ExitDate
                    }).ToList()
            };
        }
        public void Create(CreateEmployeeDto Dto)
        {
            var Employee = new EmployeeDbEntity()
            {
                Name = Dto.Name,
                Address = Dto.Address,
                EmploymentDate = Dto.EmploymentDate,
                Phone = Dto.Phone,
                Salary = Dto.Salary,
            };
            _DB.Employees.Add(Employee);
            _DB.SaveChanges();
        }

        public void Update(UpdateEmployeeDto Dto)
        {
            var Employee = _DB.Employees.SingleOrDefault(x => x.Id == Dto.Id && !x.IsDelete);
            Employee.Name = Dto.Name;
            Employee.Phone = Dto.Phone;
            Employee.Address = Dto.Address;
            Employee.Salary = Dto.Salary;
            Employee.EmploymentDate = Dto.EmploymentDate;
            _DB.Employees.Update(Employee);
            _DB.SaveChanges();
        }
        public void Delete(int id)
        {
            var Employee = _DB.Employees.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            Employee.IsDelete = true;
            _DB.Employees.Update(Employee);
            _DB.SaveChanges();

        }
    }
}
