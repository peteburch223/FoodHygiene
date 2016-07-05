using System;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;

namespace InfinityWorks_TechTest.ControllerFactories
{
    public class IoCControllerFactory : DefaultControllerFactory
    {

        private readonly IUnityContainer container;

        public IoCControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
                return container.Resolve(controllerType) as IController;
            else
                return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}