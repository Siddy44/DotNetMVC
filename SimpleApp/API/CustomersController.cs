using AutoMapper;
using SimpleApp.Context;
using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace SimpleApp.API
{
    public class CustomersController : ApiController
    {
        private CustomerContext _context;
        public CustomersController()
        {
            _context= new CustomerContext();
        }

        //GET  Api/Customers
        public IEnumerable<CustomerDto> GetCustomers()                    //Using Data Transfer Object instead of domain classes
        {
            return _context.Customer.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET Api/Customers/id

        public CustomerDto GetCustomers(int id) 
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }

        //POST api/customers

        [HttpPost]
        public CustomerDto CreateCustomer (CustomerDto customerDto)
        {
            if(!ModelState.IsValid) 
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);                 //AutoMApper
            _context.Customer.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id; 
            return customerDto;
        }

        //PUT  api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto) 
        {
           var dbContext = _context.Customer.SingleOrDefault(c => c.Id==id);
            if (dbContext == null)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            Mapper.Map<CustomerDto, Customer>(customerDto, dbContext);           //Auto Mapper
            //dbContext.Name= customer.Name;
            //dbContext.Birthdate= customer.Birthdate;
            //dbContext.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //dbContext.MembershipTypeId= customer.MembershipTypeId;
            _context.SaveChanges();
        }

        //Delete  api/customers/1
        [HttpDelete]

        public void DeleteCustomer(int id) 
        {
        var dbContext = _context.Customer.SingleOrDefault(c =>c.Id==id);
            if (dbContext == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customer.Remove(dbContext);
            _context.SaveChanges();
        }
    }
}
