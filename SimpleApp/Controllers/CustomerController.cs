using SimpleApp.Context;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using SimpleApp.ViewModel;

namespace SimpleApp.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerContext _context;
        public CustomerController()
        {
            _context= new CustomerContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipType = membershipType,
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id==0)
            _context.Customer.Add(customer);
            else
            {                //to update entity we need the data from database first
                var customerInDb =_context.Customer.Single(c =>c.Id==customer.Id);      //not using default beacuse if the given id not found it will not throw an exception
                customerInDb.Name = customer.Name;          //to map properties for updation
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId= customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList(),
            };
            return View("New",viewModel);
        }
        public ActionResult Delete(int id)
        {

            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult DeleteRecord(Customer customer)
        {
            var customer_temp = _context.Customer.Find(customer.Id);
            //if (customer_temp == null)

            _context.Customer.Remove(customer_temp);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult check()
        {
            return View();
        }
    }
}
    
