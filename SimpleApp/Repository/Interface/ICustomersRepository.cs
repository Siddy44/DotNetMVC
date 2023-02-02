using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Repository.Interface
{
    public interface ICustomersRepository
    {
        IEnumerable<CustomerDto> GetCustomers();
        CustomerDto CustomerGetById(int id);

        CustomerDto CreateCustomer(CustomerDto customer);

        CustomerDto UpdateCustomer(int id, CustomerDto customer);

        void DeleteCustomer(int id);
    }

}