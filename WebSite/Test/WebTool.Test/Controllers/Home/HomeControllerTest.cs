namespace WebTool.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Moq;
    using NUnit.Framework;
    using WebToolService;

    [TestFixture]
    public class HomeControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.HomeController; } }

        private HomeController HomeController { get; set; }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.HomeController = this.Container.Resolve<HomeController>();
        }

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
    }
}