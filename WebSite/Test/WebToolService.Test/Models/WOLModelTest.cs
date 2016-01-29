namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.Practices.Unity;
    using NUnit.Framework;
    using Utilities;

    [TestFixture]
    public class WOLModelTest : TestBase
    {
        private WolModel WolModel { get; set; }

        [TestFixtureSetUp]
        public override void Init()
        {
            base.Init();
            this.WolModel = new WolModel();
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
    }
}