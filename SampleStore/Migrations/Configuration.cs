namespace SampleStore.Migrations
{
    using SampleStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleStore.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleStore.Models.StoreContext context)
        {
            context.Products.AddOrUpdate(p => p.Name, new Product { Name = "PlayStation 4", Category = "Gaming", Price = 399M });
            context.SaveChanges();
        }
    }
}
