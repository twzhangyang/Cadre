using CadreManagement.ApplicationService.Exceptions;
using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using FluentAssertions;
using NUnit.Framework;

namespace CadreManagement.DomainUnitTests.UserTests
{
    [TestFixture]
    public class UserLoginTests : TestBase
    {
        [Test]
        public void When_LoginWithInexistentEmail_Should_ThrowException()
        {
            //Arrange
            var loginScenario = new LoginScenario(Container)
            {
                Email = "other@google.com",
            };

            //Act
            loginScenario.Invoking(s => s.Execute()).ShouldThrow<ApplicationServiceException>("no such user");

        }

        [Test,Ignore("nothing")]
        public void When_LoginWithWrongPassword_Should_ReturnFalse()
        {
            //Arrange
            var loginScenario = new LoginScenario(Container)
            {
                Password = "wrongPassword"
            };

            //Act
            loginScenario.Execute();

            //Assert
            loginScenario.Login.Should().BeFalse();
        }

        [Test]
        public void When_LoginWithCorrectPassword_Should_ReturnTrue()
        {
            //Arrange
            var loginScenario = new LoginScenario(Container);


            //Act
            loginScenario.Execute();

            //Assert
            loginScenario.Login.Should().BeTrue();
        }
    }
}