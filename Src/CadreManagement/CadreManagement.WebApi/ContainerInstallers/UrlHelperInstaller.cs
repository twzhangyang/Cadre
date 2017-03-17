using System.Web;
using System.Web.Http.Routing;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.WebApi.ContainerInstallers
{
    public class UrlHelperInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<UrlHelper>().ImplementedBy<UrlHelper>().LifestylePerWebRequest());
        }
    }
}