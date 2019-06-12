using Belatrix.WebApi.Repository.Postgresql;

using GenFu;

using System;

using System.Collections.Generic;

using System.Text;



namespace Belatrix.WebApi.Tests.Builder.Data

{

    public partial class BelatrixDbContextBuilder

    {

        public BelatrixDbContextBuilder AddTenCustomers()

        {

            AddCustomers(_context);

            return this;

        }

        private void AddCustomers(BelatrixDbContext context)
        {
            var customerList = A.ListOf<Models.Customer>(10);
            context.Customers.AddRange(customerList);
            context.SaveChanges();
        }

    }

}