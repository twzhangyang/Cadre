using System;
using CadreManagement.ApplicationService.Contracts;
using Castle.Windsor;

namespace CadreManagement.DomainUnitTests.UserTests.Scenarios
{
    public class LoginScenario:ScenarioBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Login { get; private set; }
        public DateTime LastLoginDate { get; private set; }
        public Guid Id { get; private set; }
        public LoginScenario(IWindsorContainer container) : base(container)
        {
            var registerScenario=new RegisterUserScenario(container);
            registerScenario.Execute();

            Id = registerScenario.Id;
            Email = registerScenario.GivingModel.Email;
            Password = registerScenario.GivingModel.Password;
            LastLoginDate = registerScenario.GivingModel.LastLoginDateTime;
        }

        public override void Execute()
        {
            var userService = Container.Resolve<IUserService>();

            Login=userService.Login(Email, Password);
        }
    }
}