using Moq;
using Ninject;
using SampleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleStore.Infrastracture
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;


        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAll()).Returns(new List<Product> {
                new Product { Name = "Second Son", Price = 25 },
                new Product { Name = "First Son", Price = 35},
                new Product { Name = "Third SOn", Price = 45}
            }.AsEnumerable());
            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }

    }
}