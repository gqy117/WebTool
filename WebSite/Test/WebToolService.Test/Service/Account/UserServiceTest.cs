namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;
    using WebTool;

    [TestFixture]
    public class UserServiceTest : TestBase
    {
        private UserService UserService { get; set; }

        [TestFixtureSetUp]
        public override void Init()
        {
            base.Init();
            this.UserService = this.Container.Resolve<UserService>();
        }

        [Test]
        public void GetUserModelByName_ShouldReturn1_WhenTheUserNameIs1()
        {
            // Arrange

            // Act
            var actual = this.UserService.GetUserModelByName("1");

            // Assert
            UserModel expected = new UserModel()
            {
                UserId = 1,
                UserName = "1",
            };

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}