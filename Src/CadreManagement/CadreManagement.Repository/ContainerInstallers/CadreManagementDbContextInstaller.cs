using System.Data.Common;
using System.Data.Entity;
using CadreManagement.Repository.EntityFramework;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CadreManagement.Repository.ContainerInstallers
{
    public class CadreManagementDbContextInstaller:IWindsorInstaller
    {
        public const string CadreManagementDbContextKey = "CadreManagementDbContext";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DbContext>()
               .ImplementedBy<CadreManagementDbContext>()
               .Named(CadreManagementDbContextKey)
               .LifestylePerWebRequest());
        }
    }
}