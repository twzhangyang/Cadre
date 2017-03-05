using System;
using CadreManagement.ApplicationService.Contracts;
using Castle.Windsor;

namespace CadreManagement.DomainUnitTests.UserTests.Scenarios
{
    public class ChangePasswordScenario:ScenarioBase
    {
        public string NewPassword { get; set; }
        public string Password { get; set; }

        public string Email { get; private set; }
        public Guid Id { get; private set; }

        public ChangePasswordScenario(IWindsorContainer container) : base(container)
        {
            var registerScenario=new RegisterUserScenario(container);
            registerScenario.Execute();

            Id = registerScenario.Id;
            Password = registerScenario.GivingModel.Password;
            Email = registerScenario.GivingModel.Email;
            NewPassword = "Password2";
        }


        public override void Execute()
        {
            var userService = Container.Resolve<IUserService>();

            userService.ChangePassword(Id,Password,NewPassword);
        }
    }
}