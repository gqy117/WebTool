﻿namespace WebTool.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ErrorControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.ErrorController; } }

        private ErrorController ErrorController { get; set; }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.ErrorController = this.Container.Resolve<ErrorController>();
        }

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
    }
}