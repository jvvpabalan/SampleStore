using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SampleStore.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("name=StoreContext")
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}