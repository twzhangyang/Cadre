using System;
using CadreManagement.ApplicationService.Contracts;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace CadreManagement.DomainUnitTests
{
    public class TestBase : IDisposable
    {
        private readonly IDisposable _scope;

        protected IWindsorContainer Container { get; }

        protected IUserService UserService => Container.Resolve<IUserService>();

        public TestBase()
        {
            Container = TestingBootstrap.CreateContainer();
            _scope = Container.BeginScope();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}