using System;
using System.Collections.Generic;
using System.Text;
using Task3Garage.Core.Dto;
using Task3Garage.Core.ViewModels;
using Task3Garage.Data;

namespace Task3Garage.Service.Services.CarService
{
    public interface ICarService
    {
        List<CarVM> Index();
        CarVM Details(int id);
        void Create(CreateCarDto dTO);
        void Update(UpdateCarDto dTO);
        void Delete(int id);
    }
}
