namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using Moq;
    using NUnit.Framework;
    using Utilities;

    [TestFixture]
    public class WOLModelTest : TestBase
    {
        private WolModel WolModel { get; set; }
        private Mock<ICmdHelper> MockCmdHelper { get; set; }

        [TestFixtureSetUp]
        public override void Init()
        {
            base.Init();
            this.InitCmdHelper();
            this.WolModel = new WolModel();
            this.WolModel.CmdHelper = this.MockCmdHelper.Object;
        }

        private void InitCmdHelper()
        {
            this.MockCmdHelper = new Mock<ICmdHelper>();
        }

        [Test]
        public void PrepareArgument_ShouldSetArgumentsAndFilenameToCmdHelper()
        {
            // Arrange
            this.WolModel.MacAddress = "MacAddress";
            this.WolModel.HostName = "HostName";
            this.WolModel.FileName = "Filename1";

            // Act
            this.WolModel.PrepareArgument();
            string actual = this.WolModel.Arguments;


            // Assert
            string expected = "\"MacAddress\" \"HostName\" \"255.255.255.255\" \"9\"";

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Wake_ShouldCallRunWithFileNameArguments()
        {
            // Arrange
            this.WolModel.FileName = "Filename";
            this.WolModel.Arguments = "Arguments";
            Expression<Action<ICmdHelper>> run = x => x.Run(this.WolModel.FileName, this.WolModel.Arguments);
            this.MockCmdHelper.Setup(run);

            // Act
            this.WolModel.Wake();

            // Assert
            this.MockCmdHelper.Verify(run, Times.Once);
        }
    }
}