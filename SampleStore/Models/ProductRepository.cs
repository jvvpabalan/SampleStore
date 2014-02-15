using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private StoreContext context = new StoreContext();


        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product Get(int id)
        {
            return context.Products.Find(id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            context.Products.Add(item);
            context.SaveChanges();
            return item;

        }

        public void Remove(int id)
        {
            var productToRemove = context.Products.Find(id);
            if (productToRemove != null)
            {
                context.Products.Remove(productToRemove);
                context.SaveChanges();
            }
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var product = context.Products.Find(item.Id);
            if (product == null)
            {
                return false;
            }
            context.Entry(product).CurrentValues.SetValues(item);
            context.SaveChanges();
            return true;
        }

    }
}