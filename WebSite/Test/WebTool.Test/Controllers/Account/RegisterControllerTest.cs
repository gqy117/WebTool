namespace WebTool.Test
{
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class RegisterControllerTest : ControllerTestBase
    {
        protected override Controller Controller => this.RegisterController;

        private RegisterController RegisterController { get; set; }

        [Test]
        public void Index_ShouldReturnViewResultOfRegister()
        {
            // Arrange

            // Act
            var view = this.RegisterController.Index();
            string actual = ((ViewResult)view).ViewName;

            // Assert
            string expected = "~/Views/Account/Register/Register.cshtml";
            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.RegisterController = this.Container.Resolve<RegisterController>();
        }
    }
}