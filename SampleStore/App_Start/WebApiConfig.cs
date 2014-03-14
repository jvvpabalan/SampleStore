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
            var kernel = new StandardKernel();
            kernel.Bind<IStoreContext>().To<StoreContext>();
            kernel.Bind<IProductRepository>().To<ProductRepository>();
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
