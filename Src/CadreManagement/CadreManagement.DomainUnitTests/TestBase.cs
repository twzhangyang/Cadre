using System;
using System.Data.Entity;
using CadreManagement.ApplicationService.Contracts;
using CadreManagement.Repository.EntityFramework;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using NUnit.Framework;

namespace CadreManagement.DomainUnitTests
{
    public class TestBase : IDisposable
    {
        private  IDisposable _scope;

        protected IWindsorContainer Container { get; set; }

        protected IUserService UserService => Container.Resolve<IUserService>();

        [SetUp]
        public void CreateScope()
        {
            Container = TestingBootstrap.CreateContainer();
            _scope = Container.BeginScope();
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            Database.SetInitializer(new DropCreateDatabaseAlways<CadreManagementDbContext>());
        }

        [TearDown]
        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}