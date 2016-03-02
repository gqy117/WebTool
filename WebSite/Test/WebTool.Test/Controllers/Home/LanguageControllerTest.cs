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
    public class LanguageControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.LanguageController; } }

        private LanguageController LanguageController { get; set; }

        [Test]
        public void Index_ShouldReturnPartialViewWithTheNameOfLanguageBar_AndCallGetLanguageModelMethod()
        {
            // Arrange
            this.MockLanguageService.Setup(x => x.GetLanguageModel(It.IsAny<string>())).Returns(null as LanguageModel);

            // Act
            var result = this.LanguageController.Index();
            string actual = (result as PartialViewResult).ViewName;

            // Assert
            string expected = "~/Views/Head/Language/LanguageBar.cshtml";
            actual.ShouldBeEquivalentTo(expected);
        }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.LanguageController = this.Container.Resolve<LanguageController>();
        }
    }
}