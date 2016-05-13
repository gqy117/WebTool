namespace WebToolService.Test
{
    using System;
    using System.Linq.Expressions;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;
    using Utilities;

    [TestFixture]
    public class WOLModelTest : TestBase
    {
        private Mock<ICmdHelper> MockCmdHelper { get; set; }

        private WolModel WolModel { get; set; }

        [SetUp]
        public override void Init()
        {
            base.Init();
            this.InitCmdHelper();
            this.WolModel = new WolModel();
            this.WolModel.CmdHelper = this.MockCmdHelper.Object;
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

        private void InitCmdHelper()
        {
            this.MockCmdHelper = new Mock<ICmdHelper>();
        }
    }
}