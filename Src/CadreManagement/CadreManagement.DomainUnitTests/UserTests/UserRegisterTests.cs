using System;
using CadreManagement.ApplicationService.Exceptions;
using CadreManagement.DomainModel;
using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using FluentAssertions;
using Xunit;

namespace CadreManagement.DomainUnitTests.UserTests
{
    [Collection("IntegrationTests")]
    public class UserRegisterTests : TestBase
    {
        [Fact]
        public void When_RegisterUserWithEmptyName_Should_ThrowException()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = string.Empty,
                    Email = "lilei@google.com",
                    Password = "Password1"
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<Exception>("invalid username");
        }


        [Fact]
        public void When_RegisterUserWithValidData_Should_CreateUser()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container);

            //Act
            scenario.Execute();
        }

        [Fact]
        public void When_RegisterUserWithSameEmailTwice_Should_ThrowException()
        {
            //Arrange
            var scenario=new RegisterUserScenario(Container);

            //Act
            scenario.Execute();

            scenario.Invoking(s => s.Execute()).ShouldThrow<DuplicateEmailException>("email already exist");
        }
    }
}