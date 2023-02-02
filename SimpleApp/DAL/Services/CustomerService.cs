using AutoMapper;
using SimpleApp.Context;
using SimpleApp.DAL.Services.Interface;
using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SimpleApp.DAL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerContext _context;
        public CustomerService()
        {
            _context= new CustomerContext();
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }
        public Customer CustomerGetById(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            return customer;
        }

        public Customer CreateCustomer(Customer customer) 
        {
          _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer (int id, CustomerDto customer) 
        {

            var customerfromDb = _context.Customer.SingleOrDefault(c => c.Id == id);
            Mapper.Map<CustomerDto, Customer>(customer, customerfromDb);

            _context.SaveChanges();

            return customerfromDb;

        }
        public Customer DeleteCustomer (int id)
        {
            var dbContext = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (dbContext == null) 
            throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customer.Remove(dbContext);
            _context.SaveChanges();
            return dbContext;
        }
    }
}