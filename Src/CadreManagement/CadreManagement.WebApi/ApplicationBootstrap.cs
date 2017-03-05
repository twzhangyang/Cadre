using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CadreManagement.WebApi
{
    public class ApplicationBootstrap
    {
        public static IWindsorContainer SetupContainer()
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());

            return container;
        } 
    }
}