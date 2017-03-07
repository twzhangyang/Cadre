using System;
using CadreManagement.ApplicationService.Contracts;
using CadreManagement.Model;
using Castle.Windsor;

namespace CadreManagement.DomainUnitTests.UserTests.Scenarios
{
    public class RegisterUserScenario : ScenarioBase
    {
        public UserModel GivingModel { get; set; }

        public Guid Id { get; private set; }

        public RegisterUserScenario(IWindsorContainer container):base(container)
        {
            GivingModel = new UserModel()
            {
                Name = "Lilei",
                Password = "Password1",
                Email = "lilei@google.com",
            };
        }

        public override void Execute()
        {
            var userService = Container.Resolve<IUserService>();
            Id = userService.Register(GivingModel);
        }
    }
}