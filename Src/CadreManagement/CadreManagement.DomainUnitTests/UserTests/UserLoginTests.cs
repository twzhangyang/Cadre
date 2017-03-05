using CadreManagement.ApplicationService.Exceptions;
using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace CadreManagement.DomainUnitTests.UserTests
{
    [Collection("IntegrationTests")]
    public class UserLoginTests:TestBase
    {
       [Fact]
       public  void When_LoginWithInexistentEmail_Should_ThrowException()
       {
            //Arrange
            var loginScenario=new LoginScenario(Container)
            {
                Email = "other@google.com",
            };

            //Act
           loginScenario.Invoking(s => s.Execute()).ShouldThrow<ApplicationServiceException>("no such user");

       }

        [Fact]
       public void When_LoginWithWrongPassword_Should_ReturnFalse()
       {
            //Arrange
            var loginScenario=new LoginScenario(Container)
            {
                Password = "wrongPassword"
            };

            //Act
            loginScenario.Execute();

            //Assert
           loginScenario.Login.Should().BeFalse();
       } 

        [Fact]
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