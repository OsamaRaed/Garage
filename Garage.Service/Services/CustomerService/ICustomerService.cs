using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.CustomerService
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
