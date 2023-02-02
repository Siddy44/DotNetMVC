using AutoMapper;
using SimpleApp.Context;
using SimpleApp.DAL;
using SimpleApp.DAL.Services;
using SimpleApp.DAL.Services.Interface;
using SimpleApp.Dtos;
using SimpleApp.Models;
using SimpleApp.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace SimpleApp.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ICustomerService customerService;
        public CustomersRepository()
        {
            customerService = new CustomerService();
        }
        public  IEnumerable<CustomerDto> GetCustomers()                    
        {
           
            return customerService.GetAll().ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        public CustomerDto CustomerGetById(int id) 
        {
            
            var customer = customerService.CustomerGetById(id);
            var data=Mapper.Map<Customer, CustomerDto>(customer);
            return data;
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            customerService.CreateCustomer(customer);
           
            customerDto.Id = customer.Id;
            return customerDto;
        }

        public CustomerDto UpdateCustomer (int id, CustomerDto customerDto)
        {
           
             
            customerService.UpdateCustomer( id,customerDto);
            return customerDto;
        }

        public void DeleteCustomer(int id) 
        { 
           customerService.DeleteCustomer( id);
         
        
        }
    }
}