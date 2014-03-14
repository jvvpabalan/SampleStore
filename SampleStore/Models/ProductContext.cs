using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SampleStore.Models
{
    public class StoreContext : DbContext, IStoreContext
    {
        public StoreContext() : base("name=StoreContext")
        {
        }
        public IDbSet<Product> Products { get; set; }


        public void SetValues(Product current, Product newVal)
        {
            Entry(current).CurrentValues.SetValues(newVal);
        }

        
    }
}