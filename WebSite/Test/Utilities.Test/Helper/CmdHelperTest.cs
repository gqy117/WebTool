namespace Utilities.Test
{
    using System;
    using System.ComponentModel;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class CmdHelperTest
    {
        private CmdHelper CmdHelper { get; set; }

        [SetUp]
        public void Init()
        {
            this.CmdHelper = new CmdHelper();
        }

        [Test]
        public void Run_ShouldThrowAnException_WhenTheFileDoesNotExist()
        {
            // Arrange
            string fileName = "a file does not exist";
            string arguments = "any arguments";

            // Act
            Action action = () => this.CmdHelper.Run(fileName, arguments);

            // Assert
            action.ShouldThrow<Win32Exception>();
        }
    }
}