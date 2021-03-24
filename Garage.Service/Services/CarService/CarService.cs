using System;
using System.Collections.Generic;
using System.Text;
using Task3Garage.Core.Dto;
using Task3Garage.Core.ViewModels;
using Task3Garage.Data;

namespace Task3Garage.Service.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _DB;

        public CarService(ApplicationDbContext DB)
        {
            _DB = DB;
        }

        public List<CarVM> Index()

        {
            return null;

            //return _DB.Cars.Include(x => x.Category)
            //    .Include(x => x.Viewers).Select(x => new CarVM(x)).ToList();
        }

        public CarVM Details(int id)
        {
            return null;

            //return new CarVM(_DB.Cars.Include(x => x.Viewers)
            //    .SingleOrDefault(x => x.Id == id));
        }

        public void Create(CreateCarDto dTO)
        {

        }

        public void Update(UpdateCarDto dTO)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
