using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleStore.Models;
using System.Linq;
using SampleStore.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;

namespace SampleStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Give_Products()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.GetAll()).Returns(new Product[] 
                {
                    new Product { Id = 1, Name = "Prod1"},
                    new Product { Id = 2, Name = "Prod2"},
                    new Product { Id=3, Name = "Prod3"},
                    new Product { Id= 4, Name = "Prod4"},
                    new Product{ Id=5, Name="Prod5"}
                }.AsEnumerable());

            ProductsController controller = new ProductsController(mock.Object);
            IEnumerable<Product> result = (IEnumerable<Product>)controller.GetAllProducts();

            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 5);
            Assert.AreEqual(prodArray[0].Name, "Prod1");
            Assert.AreEqual(prodArray[4].Name, "Prod5");
        }

        [TestMethod]
        public void Can_Add_Product()
        {
            var mock = CreateMockObject();
            var product = new Product{ Id = 1, Name = "Prod1", Category = "Gaming", Price = 255};
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/products/1");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/products/{id}");
            mock.Setup(m => m.Add(It.IsAny<Product>())).Returns<Product>(m => new Product());

            ProductsController controller = new ProductsController(mock.Object);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;
            var result = controller.PostProduct(product);
            
            mock.Verify(m => m.Add(It.IsAny<Product>()), Times.Once());
            Assert.AreEqual(System.Net.HttpStatusCode.Created, result.StatusCode);

        }

        private Mock<IProductRepository> CreateMockObject()
        {
            return new Mock<IProductRepository>();

        }
    }
}
