using System.Collections.Generic;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Api.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Garage.Data.Models;

namespace Garage.Service.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _DB;

        public CustomerService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public PagingVM Index(int page)

        {
            var pages = Math.Ceiling(_DB.Cars.Count() / 10.0);


            if (page < 1 || page > pages)
            {
                page = 1;
            }

            var skip = (page - 1) * 10;
            var Cars = _DB.Customers.Include(x => x.Cars)
                .Select(x => new CustomerVM()
                {
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                    Cars = x.Cars
                    .Select(y => new CarVM()
                    {
                        Model = y.Model,
                        Brand = y.Brand,
                        Color = y.Color

                    }).ToList()
                }).Skip(skip).Take(10).ToList();
            var paging = new PagingVM()
            {
                Data = Cars,
                NumberOfPages = (int)pages,
                CureentPage = page
            };
            return paging;

        }

        public CustomerVM Details(int id)
        {
            var Customer = _DB.Customers.Include(x => x.Cars)
     .SingleOrDefault(x => x.Id == id);
            return new CustomerVM()
            {
                Name = Customer.Name,
                Address = Customer.Address,
                Phone = Customer.Phone,
                Cars = Customer.Cars
                    .Select(y => new CarVM()
                    {
                        Model = y.Model,
                        Brand = y.Brand,
                        Color = y.Color

                    }).ToList()
            };

        }

        public void Create(CreateCustomerDto dTO)
        {
            var Customer = new CustomerDbEntity()
            {
                Name = dTO.Name,
                Address = dTO.Address,
                Phone = dTO.Phone,
            };
            _DB.Customers.Add(Customer);
            _DB.SaveChanges();
        }

        public void Update(UpdateCustomerDto dTO)
        {
            var Customer = _DB.Customers.SingleOrDefault(x => x.Id == dTO.Id && !x.IsDelete);
            Customer.Name = dTO.Name;
            Customer.Address = dTO.Address;
            Customer.Phone = dTO.Phone;
            _DB.Customers.Update(Customer);
            _DB.SaveChanges();
        }

        public void Delete(int id)
        {
            var Customer = _DB.Customers.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            Customer.IsDelete = true;
            _DB.Customers.Update(Customer);
            _DB.SaveChanges();

        }
    }
}
