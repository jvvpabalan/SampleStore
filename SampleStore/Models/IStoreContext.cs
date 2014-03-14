using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleStore.Models
{
    public interface IStoreContext
    {
        IDbSet<Product> Products { get; set; }
        int SaveChanges();
        void SetValues(Product current, Product newVal);
    }
}
