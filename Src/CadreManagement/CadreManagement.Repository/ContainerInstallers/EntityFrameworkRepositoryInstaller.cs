using CadreManagement.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.Repository.ContainerInstallers
{
    public class EntityFrameworkRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn(typeof(IRepository<>))
                    .WithServiceAllInterfaces()
                    .LifestylePerWebRequest());

        }
    }
}