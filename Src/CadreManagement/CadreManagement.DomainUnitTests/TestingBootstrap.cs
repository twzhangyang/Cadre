using CadreManagement.ApplicationService.ContainerInstallers;
using CadreManagement.ApplicationService.UowHelper;
using CadreManagement.Core;
using CadreManagement.Core.ContainerInstallers;
using CadreManagement.DomainUnitTests.WindsorContainer;
using CadreManagement.Repository.ContainerInstallers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CadreManagement.DomainUnitTests
{
    public class TestingBootstrap
    {
        public static void SetupContainer(IWindsorContainer container)
        {
            UnitOfWorkRegistrar.Initialize(container);

            container.ChangeComponentsLifestyleToScoped();

            container.Install(FromAssembly.This());
            container.Install(FromAssembly.Containing<UowInstaller>());
            container.Install(FromAssembly.Containing<RepositoryContextInstaller>());
            container.Install(FromAssembly.Containing<ApplicationServiceInstaller>());

        }
    }
}