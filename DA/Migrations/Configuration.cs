namespace DA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DA.Context.AirdropContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DA.Context.AirdropContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           
            //Admin
            context.Admins.AddOrUpdate(new Models.Admin
            {
                Name= "admin",
                Email= "admin@gmail.com",
                Password= "adminn",
                Phone= "01770848793"
            });
            context.Customers.AddOrUpdate(new Models.Customer
            {
                Name = "customer",
                Address = "bashundhora, Dhaka",
                Phone = "01700000000"
            });

        }
    }
}
