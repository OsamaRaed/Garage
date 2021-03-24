using System;
using System.Collections.Generic;
using System.Text;
using Task3Garage.Data;
using Task3Garage.Core.Dto;
using Task3Garage.Core.ViewModels;

namespace Task3Garage.Service.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _DB;

        public CustomerService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<CustomerVM> Index()

        {
            //return _DB.Customers.Include(x => x.Category)
                //.Include(x => x.Viewers).Select(x => new CustomerVM(x)).ToList();
            return null;

        }

        public CustomerVM Details(int id)
        {
            //return new CustomerVM(_DB.Customers.Include(x => x.Viewers)
            //    .SingleOrDefault(x => x.Id == id));
            return null;

        }

        public void Create(CreateCustomerDto dTO)
        {

        }

        public void Update(UpdateCustomerDto dTO)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
