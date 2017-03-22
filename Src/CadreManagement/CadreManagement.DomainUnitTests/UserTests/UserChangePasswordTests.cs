using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using FluentAssertions;
using NUnit.Framework;

namespace CadreManagement.DomainUnitTests.UserTests
{
    public class UserChangePasswordTests : TestBase
    {
        [Test]
        public void When_ChangePasswordWithValidValue_Should_ChangeSuccessfull()
        {
            //Arrange
            var changePasswordScenario = new ChangePasswordScenario(Container);

            //Act
            changePasswordScenario.Execute();

            //Assert
            var login = UserService.Login(changePasswordScenario.Email, changePasswordScenario.NewPassword);
            login.Should().BeTrue();
        }
    }
}