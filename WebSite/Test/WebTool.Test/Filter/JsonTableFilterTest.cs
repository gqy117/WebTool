﻿namespace WebTool.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Moq;
    using NUnit.Framework;
    using WebToolService;

    [TestFixture]
    public class JsonTableFilterTest
    {
        private ActionExecutingContext ControllerContext;

        private Mock<TableBaseController> MockTableBaseController;

        private Expression<Action<TableBaseController>> ReBindJQueryTable;
        
        private JsonTableAttribute JsonTableAttribute { get; set; }

        [SetUp]
        public void Init()
        {
            this.JsonTableAttribute = new JsonTableAttribute();

            this.MockTableBaseController = new Mock<TableBaseController>();

            this.InitControllerContext();
            this.InitMockMethods();
        }

        [Test]
        public void OnActionExecuting_ShouldReturn_WhenTheControllerIsNotTableBaseController()
        {
            // Arrange
            this.ControllerContext.Controller = new HomeController();

            // Act
            this.JsonTableAttribute.OnActionExecuting(ControllerContext);

            // Assert
            MockTableBaseController.Verify(ReBindJQueryTable, Times.Never);
        }

        [Test]
        public void OnActionExecuting_ShouldCallReBindJQueryTable_WhenTheControllerIsTableBaseController()
        {
            // Arrange

            // Act
            this.JsonTableAttribute.OnActionExecuting(ControllerContext);

            // Assert
            MockTableBaseController.Verify(ReBindJQueryTable, Times.Once);
        }

        private void InitControllerContext()
        {
            this.ControllerContext = new ActionExecutingContext();
            this.ControllerContext.Controller = this.MockTableBaseController.Object;
            this.ControllerContext.ActionParameters = new Dictionary<string, object>()
            {
                { "model", new JQueryTable() }
            };
        }

        private void InitMockMethods()
        {
            this.ReBindJQueryTable = x => x.ReBindJQueryTable(It.IsAny<JQueryTable>());

            this.MockTableBaseController.Setup(ReBindJQueryTable);
        }
    }
}