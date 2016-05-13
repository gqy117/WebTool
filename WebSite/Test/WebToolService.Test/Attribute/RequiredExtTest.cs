namespace WebToolService.Test
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class RequiredExtTest
    {
        [Test]
        public void Enabled_ShouldBeTrue_ByDefault()
        {
            // Arrange
            RequiredExtAttribute requiredExt = new RequiredExtAttribute();

            // Act
            bool actual = requiredExt.Enabled;

            // Assert
            bool expected = true;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Isvalid_ShouldReturnTrue_WhenEnabledIsFalse()
        {
            // Arrange
            RequiredExtAttribute requiredExt = new RequiredExtAttribute(false);
            object valueToCheck = null;

            // Act
            bool actual = requiredExt.IsValid(valueToCheck);

            // Assert
            bool expected = true;

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}