using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Garage.Api.Data;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;
using Garage.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Garage.Service.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _DB;

        public CarService(ApplicationDbContext DB)
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
            var Cars =  _DB.Cars.Include(x => x.MaintenanceService)
                .Select(x => new CarVM() 
                { 
                    Brand = x.Brand,
                    Model = x.Model,
                    Color = x.Color,
                    MaintenanceServices = x.MaintenanceService
                    .Select(y => new MaintenanceServiceVM()
                    { 
                        EntryDate = y.EntryDate,
                        ExitDate = y.ExitDate
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

        public CarVM Details(int id)
        {

           var Car = _DB.Cars.Include(x => x.MaintenanceService)
                .SingleOrDefault(x => x.Id == id);
            return new CarVM()
            {
                Brand = Car.Brand,
                Model = Car.Model,
                Color = Car.Color,
                MaintenanceServices = Car.MaintenanceService
                    .Select(y => new MaintenanceServiceVM()
                    {
                        EntryDate = y.EntryDate,
                        ExitDate = y.ExitDate
                    }).ToList()
            };
        }

        public void Create(CreateCarDto dTO)
        {
            var Car = new CarDbEntity()
            {
                Brand = dTO.Brand,
                Model = dTO.Model,
                Color = dTO.Color,
                CustomerId = dTO.CustomerId,
            };
            _DB.Cars.Add(Car);
            _DB.SaveChanges();
        }

        public void Update(UpdateCarDto dTO)
        {
            var Car = _DB.Cars.SingleOrDefault(x => x.Id == dTO.Id && !x.IsDelete);
            Car.Brand = dTO.Brand;
            Car.Model = dTO.Model;
            Car.Color = dTO.Color;
            Car.CustomerId = dTO.CustomerId;
                        _DB.Cars.Update(Car);
            _DB.SaveChanges();
        }



        public void Delete(int id)
        {
            var Car = _DB.Cars.SingleOrDefault(x => x.Id == id && !x.IsDelete);
            Car.IsDelete = true;
            _DB.Cars.Update(Car);
            _DB.SaveChanges();

        }
    }
}
