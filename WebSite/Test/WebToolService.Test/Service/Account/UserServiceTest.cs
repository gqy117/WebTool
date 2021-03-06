﻿namespace WebToolService.Test
{
    using System.Linq;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class UserServiceTest : TestBase
    {
        private UserService UserService { get; set; }

        [Test]
        public void GetUserModelByName_ShouldReturn1_WhenTheUserNameIs1()
        {
            // Arrange

            // Act
            var actual = this.UserService.GetUserModelByName("Pn8YTV5phgjk62xMg9xxhw==");

            // Assert
            UserModel expected = new UserModel()
            {
                UserId = 1,
                UserName = "1",
                Password = "3gVPVdEt60jny1k3431HB3AZOR/0qOW7L6l5dBNLvgEVPgNfFg==",
            };

            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public override void Init()
        {
            base.Init();
            this.UserService = this.Container.Resolve<UserService>();
        }

        [Test]
        public void Insert_ShouldReturnFalse_AndSetErrorMessage_WhenThereIsOneWithTheSameUserId()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel
            {
                UserName = "1",
                Password = "1",
            };

            // Act
            bool actual = this.UserService.Insert(logOnModel);

            // Assert
            bool expected = false;
            actual.ShouldBeEquivalentTo(expected);
            logOnModel.ErrorMessage.ShouldBeEquivalentTo(WebToolCulture.Resource.UIResource.UserAlreadyExist);
        }

        [Test]
        public void Insert_ShouldReturnTrue_AndInsertLogonModelIntoTheDatabase_WhenThereIsNotOneWithTheSameUserId()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel
            {
                UserName = "2",
                Password = "2",
            };

            // Act
            bool actual = this.UserService.Insert(logOnModel);
            var insertedUser = this.UserService.Context.Users.Last();

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
            insertedUser.UserName.ShouldBeEquivalentTo(logOnModel.UserName);
        }

        [Test]
        public void IsExist_ShouldReturnTrue_WhenTheUser1Exists()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel
            {
                UserName = "1"
            };

            // Act
            bool actual = this.UserService.IsExist(logOnModel);

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void IsLogOnAllowed_ShouldReturnFalse_WhenThePasswordIsWrong()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel
            {
                UserName = "1",
                Password = "Any Password"
            };

            // Act
            bool actual = this.UserService.IsLogOnAllowed(logOnModel);

            // Assert
            bool expected = false;
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void IsLogOnAllowed_ShouldReturnTrue_WhenThePasswordAndUsernameMatch()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel
            {
                UserName = "1",
                Password = "1"
            };

            // Act
            bool actual = this.UserService.IsLogOnAllowed(logOnModel);

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}