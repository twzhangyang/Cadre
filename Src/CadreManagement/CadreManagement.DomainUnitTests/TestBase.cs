using System;
using CadreManagement.ApplicationService.Contracts;
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

        public string Flag = "111";

        [SetUp]
        public void CreateScope()
        {
            Flag = "empty";

            Container = TestingBootstrap.CreateContainer();
            _scope = Container.BeginScope();
        }

        [TearDown]
        public void Dispose()
        {
            Flag = "";
            _scope.Dispose();
        }
    }
}