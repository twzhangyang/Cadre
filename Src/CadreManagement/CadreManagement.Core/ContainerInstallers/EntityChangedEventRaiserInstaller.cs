using CadreManagement.Core.ServiceBus;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.Core.ContainerInstallers
{
    public class EntityChangedEventRaiserInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<EventRaiser>().LifestylePerWebRequest());
        }
    }
}