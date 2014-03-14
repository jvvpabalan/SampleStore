using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleStore.Models
{
    public class ProductRepository : IProductRepository
    {
        private IStoreContext context;

        public ProductRepository(IStoreContext context)
        {
            this.context = context;
        }

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

            var product = context.Products.FirstOrDefault(p => p.Id == item.Id);
            if (product == null)
            {
                return false;
            }
            context.SetValues(product, item);
            context.SaveChanges();
            return true;
        }

    }
}