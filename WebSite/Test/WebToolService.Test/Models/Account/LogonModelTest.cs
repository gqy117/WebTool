namespace WebToolService.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class LogonModelTest
    {
        [Test]
        public void RememberMe_ShouldBeTrue_ByDefault()
        {
            // Arrange
            LogOnModel logOnModel = new LogOnModel();

            // Action
            bool actual = logOnModel.RememberMe;

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}