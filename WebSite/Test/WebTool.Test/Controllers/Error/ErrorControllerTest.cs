namespace WebTool.Test
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ErrorControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.ErrorController; } }

        private ErrorController ErrorController { get; set; }

        [Test]
        public void Error_ShouldReturnAViewWithNameError()
        {
            // Arrange

            // Act
            ViewResult actual = this.ErrorController.Error();

            // Assert
            string expected = "Error";
            actual.ViewName.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        [Test]
        public void NotFound_ShouldReturnNotFoundView_AndSetResponseStatusTo404()
        {
            // Arrange
            Action<HttpResponseBase> setStatusCode = x => x.StatusCode = 404;
            MockResponse.SetupSet(setStatusCode);

            // Act
            ViewResult actual = this.ErrorController.NotFound();

            // Assert
            string expectedViewName = "NotFound";

            actual.ViewName.ShouldBeEquivalentTo(expectedViewName);
            MockResponse.VerifySet(setStatusCode, Times.Once);
        }

        protected override void InitController()
        {
            this.ErrorController = this.Container.Resolve<ErrorController>();
        }
    }
}