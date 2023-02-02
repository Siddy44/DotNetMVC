using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleApp.DAL
{
    public class CustomerDbContext
    {
        public class CustomersDbContext : DbContext
        {
            public DbSet<Customer> Customer { get; set; }
            public DbSet<MembershipType> MembershipType { get; set; }
        }
    }
}