using System.Data.Common;
using System.Data.Entity;
using CadreManagement.Repository.EntityFramework;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Effort;

namespace CadreManagement.DomainUnitTests.WindsorInstallers
{
    public class FakeDbContextInstaller:IWindsorInstaller
    {
        public const string DbConnectionKey = "FakeDbConnection";
        public const string FakedCadreManagementDbContextKey = "FakedCadreManagementDbContext";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(
                Component.For<DbConnection>().UsingFactoryMethod(DbConnectionFactory.CreateTransient)
                    .Named(DbConnectionKey)
                    .LifestyleScoped()
                    );

            container.Register(Component.For<DbContext>()
                .ImplementedBy<CadreManagementDbContext>()
                .DependsOn(Dependency.OnComponent(typeof(DbConnection), DbConnectionKey))
                .Named(FakedCadreManagementDbContextKey)
                .LifestyleScoped()
                .IsDefault());

        }
    }
}