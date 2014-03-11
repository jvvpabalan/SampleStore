using Moq;
using Ninject;
using SampleStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;



namespace SampleStore.Infrastracture
{
    public class NinjectControllerFactory : NinjectScope,IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectControllerFactory(IKernel kernel)
            :base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }



    }
}