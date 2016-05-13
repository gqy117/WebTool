namespace Utilities.Test
{
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
            bool actual = StringHelper.ContainsCaseInsensitive(source, toCheck);

            // Assert
            bool expected = true;
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}