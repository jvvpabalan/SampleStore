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
            context.Products.AddOrUpdate(p => p.Name,
                new Product[] { 
                    new Product { Name = "PlayStation 4", Price = 399M, Category = "Gaming"},
                    new Product { Name = "Xbox One", Price = 499M, Category = "Gaming" },
                    new Product { Name = "PlayStation Vita", Price = 169M, Category = "Gaming"}
                }
                
                );
            context.SaveChanges();
        }
    }
}
