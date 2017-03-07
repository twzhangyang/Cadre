using CadreManagement.ApplicationService.UowHelper;
using CadreManagement.Core;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CadreManagement.WebApi
{
    public class ApplicationBootstrap
    {
        public static IWindsorContainer SetupContainer()
        {
            var container = IocContainerCreator.Container;
            UnitOfWorkRegistrar.Initialize(container);


            container.Install(FromAssembly.This());

            return container;
        } 
    }
}