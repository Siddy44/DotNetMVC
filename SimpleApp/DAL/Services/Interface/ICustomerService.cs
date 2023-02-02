using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.DAL.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer CustomerGetById(int id);

        Customer CreateCustomer(Customer customer);

        Customer UpdateCustomer(int id ,CustomerDto customer);

        Customer DeleteCustomer (int id);
    }
}