using System;
using System.Collections.Generic;
using System.Text;
using Task3Garage.Core.Dto;
using Task3Garage.Core.ViewModels;

namespace Task3Garage.Service.Services.CustomerService
{
    public interface ICustomerService
    {
        List<CustomerVM> Index();
        CustomerVM Details(int id);
        void Create(CreateCustomerDto Dto);
        void Update(UpdateCustomerDto Dto);
        void Delete(int id);
    }
}
