using Moq;
using Ninject;
using SampleStore.Infrastracture;
using SampleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var kernel = new StandardKernel(); Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAll()).Returns(new List<Product> {
new Product { Name = "Football", Price = 25 },
new Product { Name = "Surf board", Price = 179 },
new Product { Name = "Running shoes", Price = 95 }
}.AsQueryable());
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectControllerFactory(kernel);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
