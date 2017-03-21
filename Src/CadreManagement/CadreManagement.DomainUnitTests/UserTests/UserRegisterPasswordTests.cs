using CadreManagement.Domain.Exceptions;
using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using CadreManagement.Model;
using FluentAssertions;
using NUnit.Framework;

namespace CadreManagement.DomainUnitTests.UserTests
{
    [TestFixture]
    public class UserRegisterPasswordTests : TestBase
    {
        [Test]
        public void When_RegisterUserWithEmptyPassword_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = string.Empty,
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("invalid password");
        }

        [Test]
        public void When_RegisterUserWithPassword_LessThanSixCharacters_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "12345",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password shorter than six characters");
        }

        [Test]
        public void When_RegisterUserWithPassword_MissingUppercase_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "password1",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password missing uppercase characters");
        }

        [Test]
        public void When_RegisterUserWithPassword_MissingLowercase_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
            {
                GivingModel = new UserModel()
                {
                    Name = "Lilei",
                    Password = "PASSWORD1",
                    Email = "lilei@google.com",
                }
            };

            //Act
            scenario.Invoking(s => s.Execute()).ShouldThrow<DomainException>("password missing uppercase characters");
        }
    }
}