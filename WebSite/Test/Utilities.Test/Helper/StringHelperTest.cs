namespace Utilities.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class StringHelperTest
    {
        [Test]
        public void Contains_ShouldReturnTrue_WhenItIsNotCaseSensitive()
        {
            // Arrange
            string source = "H";
            string toCheck = "h";

            // Act
            bool actual = StringHelper.Contains(source, toCheck);

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}