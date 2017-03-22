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
        private static IWindsorContainer _container;

        public static IWindsorContainer CreateContainer()
        {
            if (_container == null)
            {
                _container = IocContainerCreator.Container;
                UnitOfWorkRegistrar.Initialize(_container);

                _container.ChangeComponentsLifestyleToScoped();

                _container.Install(FromAssembly.This());
                _container.Install(FromAssembly.Containing<UowInstaller>());
                _container.Install(FromAssembly.Containing<RepositoryContextInstaller>());
                _container.Install(FromAssembly.Containing<ApplicationServiceInstaller>());
            }

            return _container;
        }
    }
}