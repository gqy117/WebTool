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
    public class IndexHeadControllerTest : ControllerTestBase
    {
        protected override Controller Controller { get { return this.IndexHeadController; } }

        private IndexHeadController IndexHeadController { get; set; }

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.IndexHeadController = this.Container.Resolve<IndexHeadController>();
        }

        [Test]
        public void Index_ShouldReturnPartialViewWithTheNameOfHead_WithDataEqualingCurrentUserModel()
        {
            // Arrange

            // Act
            var result = this.IndexHeadController.Index();
            string actual = (result as PartialViewResult).ViewName;
            object actualData = (result as PartialViewResult).Model;

            // Assert
            string expected = "~/Views/Head/Head.cshtml";
            actual.ShouldBeEquivalentTo(expected);
            actualData.ShouldBeEquivalentTo(this.IndexHeadController.CurrentUserModel);
        }
    }
}