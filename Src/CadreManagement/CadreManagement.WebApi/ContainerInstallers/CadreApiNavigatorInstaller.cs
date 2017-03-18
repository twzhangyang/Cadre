using CadreManagement.WebApi.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.WebApi.ContainerInstallers
{
    public class CadreApiNavigatorInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<CadreApiNavigator>()
                    .UsingFactoryMethod(c => new CadreApiNavigator(CadreHomeController.Home()))
                    .LifestylePerWebRequest());
        }
    }
}