﻿using System;
using System.Data.Entity;
using CadreManagement.ApplicationService.Exceptions;
using CadreManagement.DomainUnitTests.UserTests.Scenarios;
using CadreManagement.Model;
using CadreManagement.Repository.EntityFramework;
using FluentAssertions;
using NUnit.Framework;

namespace CadreManagement.DomainUnitTests.UserTests
{
    [TestFixture]
    public class UserRegisterTests : TestBase
    {
        [Test]
        public void When_RegisterUserWithEmptyName_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container)
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


        [Test]
        public void When_RegisterUserWithValidData_Should_CreateUser()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container);

            //Act
            scenario.Execute();

            var user = UserService.GetUser(scenario.Id);
            user.Name.Should().Be(scenario.GivingModel.Name);
            user.Email.Should().Be(scenario.GivingModel.Email);
        }

        [Test,Ignore("nothing")]
        public void When_RegisterUserWithSameEmailTwice_Should_ThrowException()
        {
            //Arrange
            var scenario = new RegisterUserScenario(Container);

            //Act
            scenario.Execute();

            scenario.Invoking(s => s.Execute()).ShouldThrow<DuplicateEmailException>("email already exist");
        }
    }
}