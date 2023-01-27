using SimpleApp.Context;
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
        public IEnumerable<Customer> GetCustomers() 
        { 
          return _context.Customer.ToList();
        }

        //GET Api/Customers/id

        public Customer GetCustomers(int id) 
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        //POST api/customers

        [HttpPost]
        public Customer CreateCustomer (Customer customer)
        {
            if(!ModelState.IsValid) 
            throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        //PUT  api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer) 
        {
           var dbContext = _context.Customer.SingleOrDefault(c => c.Id==id);
            if (customer == null)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            dbContext.Name= customer.Name;
            dbContext.Birthdate= customer.Birthdate;
            dbContext.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            dbContext.MembershipTypeId= customer.MembershipTypeId;
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
