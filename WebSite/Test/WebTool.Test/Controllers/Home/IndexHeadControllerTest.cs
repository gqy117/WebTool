namespace WebTool.Test
{
    using System.Web.Mvc;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;

    [TestFixture]
    public class IndexHeadControllerTest : ControllerTestBase
    {
        protected override Controller Controller => this.IndexHeadController;

        private IndexHeadController IndexHeadController { get; set; }

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

        [SetUp]
        public void Init()
        {
            base.Init();
        }

        protected override void InitController()
        {
            this.IndexHeadController = this.Container.Resolve<IndexHeadController>();
        }
    }
}