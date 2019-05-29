using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class BelatrixDbContext : DbContext
    {
        public BelatrixDbContext(DbContextOptions<BelatrixDbContext> opt) : base(opt)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
        }
    }
}
