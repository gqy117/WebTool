namespace WebTool.Test
{
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class HomeControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.HomeController; } }

        private HomeController HomeController { get; set; }

        [Test]
        public void Index_ShouldReturnPartialViewWithTheNameHome()
        {
            // Arrange

            // Act
            var result = this.HomeController.Index();
            string actual = (result as ViewResult).ViewName;

            // Assert
            string expected = "~/Views/Home/Home.cshtml";
            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.HomeController = this.Container.Resolve<HomeController>();
        }
    }
}