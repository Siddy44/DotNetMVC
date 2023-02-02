using SimpleApp.Dtos;
using SimpleApp.Repository;
using SimpleApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleApp.API
{
    public class CustomersListController : ApiController
    {
        private readonly ICustomersRepository customersList;
        public CustomersListController()
        {
            customersList = new CustomersRepository();
        }
        //GET  Api/CustomersList
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return customersList.GetCustomers();

        }

        //Get Api/CustomersList

        public CustomerDto GetCustomerById (int id)
        {
            return customersList.CustomerGetById(id);
        }

        //Post Api/CustomersList
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            return customersList.CreateCustomer(customer);
        }

        [HttpPut]
        public CustomerDto UpdateCustomer (int id, CustomerDto customer)
        {
            return customersList.UpdateCustomer(id, customer);
        }

        [HttpDelete]
        public void DeleteCustomer(int id) 
        {
           customersList.DeleteCustomer(id);
           
        }
    }
}
     