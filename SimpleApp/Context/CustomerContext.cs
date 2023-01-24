using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleApp.Context
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }

        public DbSet<Genre> Genre { get; set; }
    }
}