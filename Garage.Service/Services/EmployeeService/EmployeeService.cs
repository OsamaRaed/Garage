using System;
using System.Collections.Generic;
using System.Text;
using Garage.Data;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Api.Data;

namespace Garage.Service.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _DB;

        public EmployeeService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<EmployeeVM> Index()

        {
            return null;

            //return _DB.Employees.Include(x => x.Category)
            //    .Include(x => x.Viewers).Select(x => new EmployeeVM(x)).ToList();
        }

        public EmployeeVM Details(int id)
        {
            return null;

            //return new EmployeeVM(_DB.Employees.Include(x => x.Viewers)
            //    .SingleOrDefault(x => x.Id == id));
        }

        public void Create(CreateEmployeeDto Dto)
        {

        }

        public void Update(UpdateEmployeeDto Dto)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
