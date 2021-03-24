using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;
using Garage.Data;

namespace Garage.Service.Services.CarService
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
