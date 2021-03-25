using System;
using System.Collections.Generic;
using System.Text;
using Garage.Core.Dto;
using Garage.Core.ViewModels;

namespace Garage.Service.Services.CustomerService
{
    public interface ICustomerService
    {
        PagingVM Index(int page);
        CustomerVM Details(int id);
        void Create(CreateCustomerDto Dto);
        void Update(UpdateCustomerDto Dto);
        void Delete(int id);
    }
}
