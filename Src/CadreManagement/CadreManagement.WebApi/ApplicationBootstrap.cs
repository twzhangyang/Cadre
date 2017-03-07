using CadreManagement.ApplicationService;
using CadreManagement.ApplicationService.ContainerInstallers;
using CadreManagement.ApplicationService.UowHelper;
using CadreManagement.Core;
using CadreManagement.Core.ContainerInstallers;
using CadreManagement.Repository.ContainerInstallers;
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
            container.Install(FromAssembly.Containing<UowInstaller>());
            container.Install(FromAssembly.Containing<ApplicationServiceInstaller>());
            container.Install(FromAssembly.Containing<RepositoryContextInstaller>());


            return container;
        } 
    }
}