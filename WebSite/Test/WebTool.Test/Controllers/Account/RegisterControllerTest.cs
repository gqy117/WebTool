namespace WebTool.Test.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class RegisterControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.RegisterController; } }

        private RegisterController RegisterController { get; set; }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.RegisterController = this.Container.Resolve<RegisterController>();
        }

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
    }
}